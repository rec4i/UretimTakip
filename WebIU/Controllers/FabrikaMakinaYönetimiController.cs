using EasyModbus;
using Microsoft.AspNetCore.Mvc;
using System;
using WebIU.Models.FabrikaMakinaYönetimModels;
using WebIU.Models.HelperModels;

namespace WebIU.Controllers
{
    public class FabrikaMakinaYönetimiController : Controller
    {
        public IActionResult Fırın()
        {


            return View();
        }

        public IActionResult GetFırınStatus()
        {
            JsonResponseModel res = new JsonResponseModel();
            FırınViewModel model = new FırınViewModel();

            res.status = 1;
            try
            {
                // Modbus TCP server IP ve port bilgisi
                string ipAddress = "10.10.1.26"; // Modbus TCP sunucusunun IP adresini buraya yazın
                int port = 502; // Modbus TCP sunucusunun port numarasını buraya yazın

                // ModbusClient oluştur
                ModbusClient modbusClient = new ModbusClient(ipAddress, port);
                modbusClient.Connect();



                var buttonDurumlar = modbusClient.ReadCoils(1, 2);
                model.FırınDurdurSayac = buttonDurumlar[0];
                model.SogutmaBaslatSayac = buttonDurumlar[1];





                // Bağlan

                // Örneğin: Holding register 40001 adresinden itibaren 5 adet register oku
                int startAddress = 0; // 40001 adresi Modbus protokolünde 0 ile temsil edilir
                int numRegisters = 8;

                int[] registers = modbusClient.ReadHoldingRegisters(startAddress, numRegisters);

                model.SBASST = registers[0];
                model.SBASDK = registers[1];
                model.SBITST = registers[2];
                model.SBITDK = registers[3];

                model.BASST = registers[4];
                model.BASDK = registers[5];
                model.BITST = registers[6];
                model.BITDK = registers[7];

                modbusClient.Disconnect();

            }
            catch (Exception)
            {
                res.status = 0;
                res.message = "Veri Alınırken Hata Yaşandı Lütfen Bağlantıyı Kontrol Ediniz";
                throw;
            }
            res.data = model;

            return Json(res);

        }
        public IActionResult SetFırınStatus(FırınViewModel model)
        {
            JsonResponseModel res = new JsonResponseModel();

            res.status = 1;
            try
            {
                // Modbus TCP server IP ve port bilgisi
                string ipAddress = "10.10.1.26"; // Modbus TCP sunucusunun IP adresini buraya yazın
                int port = 502; // Modbus TCP sunucusunun port numarasını buraya yazın

                // ModbusClient oluştur
                ModbusClient modbusClient = new ModbusClient(ipAddress, port);
                modbusClient.Connect();

                // Coils yaz
                bool[] coils = new bool[] { model.FırınDurdurSayac, model.SogutmaBaslatSayac };
                modbusClient.WriteMultipleCoils(1, coils);

                // Holding register yaz
                int[] registers = new int[]
                {
            model.SBASST,
            model.SBASDK,
            model.SBITST,
            model.SBITDK,
            model.BASST,
            model.BASDK,
            model.BITST,
            model.BITDK
                };
                modbusClient.WriteMultipleRegisters(0, registers);

                modbusClient.Disconnect();
            }
            catch (Exception)
            {
                res.status = 0;
                res.message = "Veri Gönderilirken Hata Yaşandı Lütfen Bağlantıyı Kontrol Ediniz";
                throw;
            }

            return Json(res);
        }

    }
}
