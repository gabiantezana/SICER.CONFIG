using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SICER.CONFIG.USERMODEL
{
    [DBStructure]
    [SAPTable("SICER CONCEPTOS", TableType = SAPbobsCOM.BoUTBTableType.bott_NoObject)]
    class MSS_SICER_CON
    {

        [SAPField(FieldName = "Cuenta contable")]
        public string CuentaContable { get; set; }

        [SAPField(FieldName = "Descripcion")]
        public string Descripcion { get; set; }

        [SAPField(FieldName = "Codigo")]
        public string Codigo { get; set; }
    }
}
