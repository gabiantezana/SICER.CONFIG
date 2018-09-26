using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SICER.CONFIG.USERMODEL
{
    [DBStructure]
    [SAPTable("SICER CUENTAS DEVOLUCION", TableType = SAPbobsCOM.BoUTBTableType.bott_NoObject)]
    class MSS_SICER_CCDEV
    {

        [SAPField(FieldName = "Cuenta contable")]
        public string CuentaContable { get; set; }

        [SAPField(FieldName = "Descripcion")]
        public string Descripcion { get; set; }

        [SAPField(FieldName = "Codigo")]
        public string Codigo { get; set; }
    }
}
