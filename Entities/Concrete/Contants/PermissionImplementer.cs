using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Entities.Concrete.Contants
{
    public static class PermissionImplementer
    {
        public static class User
        {
            public const string Search = "Permission.User.Search";
            public const string UserInformation = "Permission.User.UserInformation";
            public const string EditUserInformation = "Permission.User.EditUserInformation";
            public const string UserDelete = "Permission.User.UserDelete";
            public const string AddUser = "Permission.User.AddUser";
        }
        public static class ViewComponents
        {
            public const string ImplementerWorldMap = "Permission.ViewComponents.ImplementerWorldMap";
        }
        public static class Tools
        {
            public const string UploadImage = "Permission.Tools.UploadImage";
        }
        public static class Home
        {
            public const string Contact = "Permission.Home.Contact";
        }
        public static class Role
        {
            public const string ImplementerRoleList = "Permission.Role.ImplementerRoleList";
            public const string CreateImplementerRole = "Permission.Role.CreateImplementerRole";
            public const string DeleteImplementerRole = "Permission.Role.DeleteImplementerRole";
            public const string ImplementerRoleEdit = "Permission.Role.ImplementerRoleEdit";
            public const string ImplementerEditPermissionInRole = "Permission.Role.ImplementerEditPermissionInRole";
            public const string ImplementerEditUserInRole = "Permission.Role.ImplementerEditUserInRole";
        }
        public static class Implementer
        {
            public const string ImplementerInformation = "Permission.Implementer.ImplementerInformation";
            public const string ImplementerEdit = "Permission.Implementer.ImplementerEdit";
            public const string MyImplementer = "Permission.Implementer.MyImplementer";
            public const string ImplementerUsers = "Permission.Implementer.ImplementerUsers";
            public const string ImplementerAuthorizedAppointment = "Permission.Implementer.ImplementerAuthorizedAppointment";
            public const string SystemInformation = "Permission.Implementer.SystemInformation";
            public const string LogList = "Permission.Implementer.LogList";
        }
        public static class Project
        {
            public const string Search = "Permission.Project.Search";
            public const string ProjectList = "Permission.Project.ProjectList";
            public const string ProjectInformation = "Permission.Project.ProjectInformation";
            public const string EditProjectInformation = "Permission.Project.EditProjectInformation";
            public const string ProjectDelete = "Permission.Project.ProjectDelete";
            public const string AddProject = "Permission.Project.AddProject";
            public const string ProjectUsers = "Permission.Project.ProjectUsers";
            public const string AssignUser = "Permission.Project.AssignUser";
            public const string ProjectAuthorizedAppointment = "Permission.Project.ProjectAuthorizedAppointment";
            public const string SeeAllProject = "Permission.Project.SeeAllProject";
            public const string SystemInformation = "Permission.Project.SystemInformation";
            public const string LogList = "Permission.Project.LogList";
        }
        public static class Event
        {
            public const string Search = "Permission.Event.Search";
            public const string EventList = "Permission.Event.EventList";
            public const string EventInformation = "Permission.Event.EventInformation";
            public const string EditEventInformation = "Permission.Event.EditEventInformation";
            public const string EventDelete = "Permission.Event.EventDelete";
            public const string AddEvent = "Permission.Event.AddEvent";
            public const string EventUsers = "Permission.Event.EventUsers";
            public const string AssignUser = "Permission.Event.AssignUser";
            public const string EventAuthorizedAppointment = "Permission.Event.EventAuthorizedAppointment";
            public const string SystemInformation = "Permission.Event.SystemInformation";
            public const string LogList = "Permission.Event.LogList";
        }
        public static class Beneficiary
        {
            public const string Search = "Permission.Beneficiary.Search";
            public const string AddBeneficiaryList = "Permission.Beneficiary.AddBeneficiaryList";
            public const string MainEventSelection = "Permission.Beneficiary.MainEventSelection";
            public const string MultipleEventAssignment = "Permission.Beneficiary.MultipleEventAssignment";
            public const string ChangeStatus = "Permission.Beneficiary.ChangeStatus";
            public const string ChangeInformation = "Permission.Beneficiary.ChangeInformation";
            public const string BeneficiaryInformation = "Permission.Beneficiary.BeneficiaryInformation";
            public const string EditBeneficiaryInformation = "Permission.Beneficiary.EditBeneficiaryInformation";
            public const string BeneficiaryDelete = "Permission.Beneficiary.BeneficiaryDelete";
            public const string AddBeneficiary = "Permission.Beneficiary.AddBeneficiary";
            public const string ActiveBeneficiaryList = "Permission.Beneficiary.ActiveBeneficiaryList";
            public const string LogList = "Permission.Beneficiary.LogList";
            public const string RemoveEventToBeneficiary = "Permission.Beneficiary.RemoveEventToBeneficiary";
            public const string AssingEventToOneBeneficiary = "Permission.Beneficiary.AssingEventToOneBeneficiary";
            public const string SeeBeneficiartEvents = "Permission.Beneficiary.SeeBeneficiartEvents";
            public const string SeeTransactionList = "Permission.Beneficiary.SeeTransactionList";
        }
        public static class Device
        {
            public const string Search = "Permission.Device.Search";
            public const string AddDeviceList = "Permission.Device.AddDeviceList";
            public const string AllDeviceList = "Permission.Device.AllDeviceList";
            public const string MainEventSelection = "Permission.Device.MainEventSelection";
            public const string MultipleEventAssignment = "Permission.Device.MultipleEventAssignment";
            public const string ChangeStatus = "Permission.Device.ChangeStatus";
            public const string ChangeInformation = "Permission.Device.ChangeInformation";
            public const string DeviceOperations = "Permission.Device.DeviceOperations";
            public const string AssingEvent = "Permission.Device.AssingEvent";
            public const string RemoveEvent = "Permission.Device.RemoveEvent";
            public const string AddDevice = "Permission.Device.AddDevice";
            public const string DeleteDevice = "Permission.Device.DeleteDevice";
            public const string EditDevice = "Permission.Device.EditDevice";
            public const string TableWithJson = "Permission.Device.TableWithJson";
            public const string DeviceInfo = "Permission.Device.DeviceInfo";
            public const string SystemInformation = "Permission.Device.SystemInformation";
            public const string EventList = "Permission.Device.EventList";
            public const string LogList = "Permission.Device.LogList";
            public const string DeviceCardReadingLogList = "Permission.Device.DeviceCardReadingLogList";
            public const string Synchronization = "Permission.Device.Synchronization";
            public const string SeeTransactionList = "Permission.Device.SeeTransactionList";
        }
        public static class Transaction
        {
            public const string DeviceTransactions = "Permission.Transaction.DeviceTransactions";
            public const string ListTransactions = "Permission.Transaction.ListTransactions";
            public const string AddTransactions = "Permission.Transaction.AddTransactions";
            public const string TransactionDetailDevice = "Permission.Transaction.TransactionDetailDevice";
            public const string TransactionDetailBeneficiary = "Permission.Transaction.TransactionDetailBeneficiary";
            public const string TransactionDetailEvent = "Permission.Transaction.TransactionDetailEvent";
        }
        public static class Announcement
        {
            public const string AnnouncementList = "Permission.Announcement.AnnouncementList";
        }

        public static IEnumerable<FieldInfo> GetPublicConstants(Type type)
        {
            return type
                .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                .Where(fi => fi.IsLiteral && !fi.IsInitOnly)
                .Concat(type.GetNestedTypes(BindingFlags.Public).SelectMany(GetPublicConstants));
        }
        public static List<string> GetPermissions()
        {
            var permissionList = new List<string>();
            foreach (var type in typeof(PermissionImplementer).GetNestedTypes().ToList())
            {
                foreach (var item in GetPublicConstants(type))
                {
                    var resultName = (item.DeclaringType.FullName + "." + item.Name).Replace(typeof(PermissionImplementer).Namespace + ".", "").Replace("+", ".").Replace("PermissionImplementer", "Permission");
                    permissionList.Add(resultName);
                }
            }
            return permissionList;
        }
    }
}


