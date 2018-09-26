using System;

namespace SAPADDON.HELPER
{
    public class ConstantHelper
    {
        public const Int32 ApplicationId = -1;
        public static Int32 DefaulSuccessSAPNumber = 0;
        public const Int32 DefaultFieldSize = 10;
        public const String ADDON_NAME = "MSS ADDON ARTÍCULOS";
        public const String DEFAULT_ERROR_MESSAGE = "Some error occurred in application.Please contact your administrator.";
        public const String DEFAULT_SUCCESS_MESSAGE = "Successfuly operation";
        public static String DATEFORMAT = "yyyyMMdd";
        public static String DEFAULTDATENULL = "30/12/1899 00:00:00";
        public static class SAP_STATE
        {
            public static String ACTIVE = "Y";
            public static String INACTIVE = "N";
        }

        public static class SAP_YES_NO
        {
            public static String YES = "Y";
            public static String NO = "N";
        }

        public static class OrigenVehiculo
        {
            public static string Propio = "01";
            public static string Tercero = "02";
        }

        public static class EstadoVehiculo
        {
            public static string Disponible = "DI";
            public static string Ruta = "RU";
            public static string EnMantenimiento = "MA";
            public static string Baja = "BA";

        }
    }
}
