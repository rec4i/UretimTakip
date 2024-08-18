using DataAccess.Abstract;
using Entities.Concrete.OtherEntities;
using Org.BouncyCastle.Asn1.Cms;
using System.Collections.Concurrent;
using System.Threading.Channels;

namespace Business.Concrate.Services.Helpers
{
    public class DataProcessorService
    {
        private readonly ConcurrentDictionary<long, List<KareKodUrunler>> _queues = new();
        private readonly ConcurrentDictionary<long, Timer> _timers = new();
        private readonly SemaphoreSlim _semaphore = new(1, 1);
        private readonly int _delayMilliseconds = 10000;
        private readonly IKareKodUrunlerRepository _kareKodUrunlerRepository;
        public DataProcessorService(IKareKodUrunlerRepository kareKodUrunlerRepository)
        {
            _kareKodUrunlerRepository = kareKodUrunlerRepository;
        }
        public async Task QueueDataAsync(KareKodUrunler data)
        {
            var seriNumarasi = data.Sn;

            await _semaphore.WaitAsync();
            try
            {
                if (!_queues.ContainsKey(seriNumarasi))
                {
                    _queues[seriNumarasi] = new List<KareKodUrunler>();
                }

                _queues[seriNumarasi].Add(data);

                if (!_timers.ContainsKey(seriNumarasi))
                {
                    _timers[seriNumarasi] = new Timer(async _ => await ProcessQueueAsync(seriNumarasi), null, _delayMilliseconds, Timeout.Infinite);
                }
                else
                {
                    _timers[seriNumarasi].Change(_delayMilliseconds, Timeout.Infinite);
                }
            }
            finally
            {
                _semaphore.Release();
            }
        }

        private async Task ProcessQueueAsync(long seriNumarasi)
        {
            await _semaphore.WaitAsync();
            try
            {
                if (_queues.TryGetValue(seriNumarasi, out var queue) && queue.Count > 0)
                {
                    foreach (var data in queue)
                    {
                        await ProcessToDatabaseAsync(data);
                    }

                    queue.Clear();
                }

                _timers.TryRemove(seriNumarasi, out _);
                _queues.TryRemove(seriNumarasi, out _);
            }
            finally
            {
                _semaphore.Release();
            }
        }

        private async Task ProcessToDatabaseAsync(KareKodUrunler data)
        {
            _kareKodUrunlerRepository.Add(data);
        }
    }
}
