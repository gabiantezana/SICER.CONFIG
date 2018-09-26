using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPADDON.HELPER
{
    public class EnumHelper
    {
    }

    public enum FormConductorItems
    {
        ButtonSave = 1
    }

    public enum _150FormItems
    {
        SaveButton = 1,
        ItemCode = 5,
        Active = 10002050,
        Inactive = 10002051,
        OptionBtn3 = 10002052,

    }

    public enum ArticleActivationFormItems
    {
        LblListado = -1,
        Grid = -2,
        Button = -3,
    }

    public enum EmbebbedFileName
    {
        AddonMenu = 1,
        SampleForm = 2,
        ArticleActivationForm = 3,
        MSS_VEHICForm = 4,
        MSS_CONFForm = 5,
        MSS_DESPForm = 6,
        MSS_DESPListForm = 7,
        MSS_APROForm = 8,

        #region Queries

        MSS_APRO_GetList = 100,
        MSS_DESP_ApproveItem = 101,
        MSS_DESP_GetDetail = 102,
        MSS_DESP_GetItem = 103,
        MSS_VEHIC_GetItem = 104,
        POR1_GetItem = 105,
        POR1_GetList = 106,

        #endregion
    }

    public enum FormID
    {
        ArticleActivationForm = -100,
        _150 = 150,
        MSS_VEHIC = -101,
        MSS_CONFIG = -102,
        MSS_DESP = -103,
        MSS_DESP_LIST = -104,
        MSS_APRO = -105,
    }

    public enum MenuUID
    {
        _150Form = 3073,
        MenuBuscar = 1281,
        MenuCrear = 1282,
        RegistroDatosSiguiente = 1288,
        RegistroDatosAnterior = 1289,
        RegistroDatosPrimero = 1290,
        RegistroDatosUltimo = 1291,
        RegistroActualizar = 1304,
        InventoryMenu = 3072,
        //ArticleActivation = -1000,
        AddonGestionDespachosMenu = -2000,
        ConfiguracionAddonSubMenu = -2002,
        MaestroVehiculosSubMenu = -2003,
        DespachoVehiculosSubMenu = -2004,
        AprobacionDespachoVehiculosSubMenu = -2005,

    }

    public enum MessageType
    {
        Success = 1,
        Info = 2,
        Error = 3,
        Warning = 4,
    }

    public enum SaveType
    {
        SaveAsPending = 1,
        SaveAsNoPending = 2,
        KeepOriginalDBValues = 3
    }

}
