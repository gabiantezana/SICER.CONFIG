using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SICER.CONFIG.USERMODEL
{
    [DBStructure]
    [SAPTable("SICER CONFIGURACIÓN CUENTAS", TableType = SAPbobsCOM.BoUTBTableType.bott_NoObject)]
    public class MSS_SICER
    {
        [SAPField(FieldName = "Documento")]
        public string Documento { get; set; }

        [SAPField(FieldName = "Cuenta contable")]
        public string CuentaContable { get; set; }

        [SAPField(FieldName = "Descripcion")]
        public string Descripcion { get; set; }

        [SAPField(FieldName = "Codigo")]
        public string Codigo { get; set; }
    }
}
