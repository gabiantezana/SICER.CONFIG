using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAPbobsCOM;
using SICER.CONFIG.USERMODEL;
using SAPADDON.HELPER;

namespace SICER.CONFIG
{
    public class Program
    {
        private const string CONNECTION_FILE = "\\conexion.xml";
        private const string FILE_OUTPUT_DIRECTION = "C:\\";

        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Inicializando conexiones...");
                var companies = initializeConnections();

                foreach (var company in companies)
                {
                    try
                    {
                        Console.WriteLine("Generando esquema para: " + company.Key);
                        GenerateDBSchema(company.Value);    
                        var defaultValues = string.Empty;

                        if (company.Value.DbServerType == BoDataServerTypes.dst_HANADB)
                        {
                            defaultValues = " INSERT INTO \"@MSS_SICER\" VALUES(1, 1, 'CC','',''	,'FFMN'); \n"
                                          + " INSERT INTO \"@MSS_SICER\" VALUES(2, 2, 'CC', '', '', 'FFME');       \n"
                                          + " INSERT INTO \"@MSS_SICER\" VALUES(3, 3, 'CC', '', '', 'DPRMN');      \n"
                                          + " INSERT INTO \"@MSS_SICER\" VALUES(4, 4, 'CC', '', '', 'DPRME');      \n"
                                          + " INSERT INTO \"@MSS_SICER\" VALUES(5, 5, 'ER', '', '', 'ERMN');       \n"
                                          + " INSERT INTO \"@MSS_SICER\" VALUES(6, 6, 'ER', '', '', 'ERME');       \n"
                                          + " INSERT INTO \"@MSS_SICER\" VALUES(7, 7, 'ER', '', '', 'ERMNI');      \n"
                                          + " INSERT INTO \"@MSS_SICER\" VALUES(8, 8, 'ER', '', '', 'ERMEI');      \n"
                                          + " INSERT INTO \"@MSS_SICER\" VALUES(9, 9, 'ER', '', '', 'ERCTAMN');    \n"
                                          + " INSERT INTO \"@MSS_SICER\" VALUES(10, 10, 'ER', '', '', 'ERCTAME');  \n"
                                          + " INSERT INTO \"@MSS_SICER\" VALUES(11, 11, 'ER', '', '', 'ERFEMN');   \n"
                                          + " INSERT INTO \"@MSS_SICER\" VALUES(12, 12, 'ER', '', '', 'ERFNEME');  \n"
                                          + " INSERT INTO \"@MSS_SICER\" VALUES(13, 13, 'RE', '', '', 'REFEMN');   \n"
                                          + " INSERT INTO \"@MSS_SICER\" VALUES(14, 14, 'RE', '', '', 'REFEME');   \n"
                                          + " INSERT INTO \"@MSS_SICER\" VALUES(15, 15, 'RE', '', '', 'REMN');     \n"
                                          + " INSERT INTO \"@MSS_SICER\" VALUES(16, 16, 'RE', '', '', 'REME');     \n"
                                          + " INSERT INTO \"@MSS_SICER\" VALUES(17, 17, 'RE', '', '', 'REDPRMN');  \n"
                                          + " INSERT INTO \"@MSS_SICER\" VALUES(18, 18, 'RE', '', '', 'REDPRME');  \n"
                                          + " INSERT INTO \"@MSS_SICER\" VALUES(19, 19, 'PP', '', '', 'REFFMN');   \n"
                                          + " INSERT INTO \"@MSS_SICER\" VALUES(20, 20, 'PP', '', '', 'REFFME');   \n";
                            Console.Write(defaultValues);
                        }
                        else
                        {

                            defaultValues = "INSERT INTO [@MSS_SICER] VALUES(	1	,   1	,'CC','',''	,'FFMN'    );"
                                                   + " INSERT INTO[@MSS_SICER] VALUES(2, 2, 'CC', '', '', 'FFME');      "
                                                   + " INSERT INTO[@MSS_SICER] VALUES(3, 3, 'CC', '', '', 'DPRMN');     "
                                                   + " INSERT INTO[@MSS_SICER] VALUES(4, 4, 'CC', '', '', 'DPRME');     "
                                                   + " INSERT INTO[@MSS_SICER] VALUES(5, 5, 'ER', '', '', 'ERMN');      "
                                                   + " INSERT INTO[@MSS_SICER] VALUES(6, 6, 'ER', '', '', 'ERME');      "
                                                   + " INSERT INTO[@MSS_SICER] VALUES(7, 7, 'ER', '', '', 'ERMNI');     "
                                                   + " INSERT INTO[@MSS_SICER] VALUES(8, 8, 'ER', '', '', 'ERMEI');     "
                                                   + " INSERT INTO[@MSS_SICER] VALUES(9, 9, 'ER', '', '', 'ERCTAMN');   "
                                                   + " INSERT INTO[@MSS_SICER] VALUES(10, 10, 'ER', '', '', 'ERCTAME'); "
                                                   + " INSERT INTO[@MSS_SICER] VALUES(11, 11, 'ER', '', '', 'ERFEMN');  "
                                                   + " INSERT INTO[@MSS_SICER] VALUES(12, 12, 'ER', '', '', 'ERFNEME'); "
                                                   + " INSERT INTO[@MSS_SICER] VALUES(13, 13, 'RE', '', '', 'REFEMN');  "
                                                   + " INSERT INTO[@MSS_SICER] VALUES(14, 14, 'RE', '', '', 'REFEME');  "
                                                   + " INSERT INTO[@MSS_SICER] VALUES(15, 15, 'RE', '', '', 'REMN');    "
                                                   + " INSERT INTO[@MSS_SICER] VALUES(16, 16, 'RE', '', '', 'REME');    "
                                                   + " INSERT INTO[@MSS_SICER] VALUES(17, 17, 'RE', '', '', 'REDPRMN'); "
                                                   + " INSERT INTO[@MSS_SICER] VALUES(18, 18, 'RE', '', '', 'REDPRME'); "
                                                   + " INSERT INTO[@MSS_SICER] VALUES(19, 19, 'PP', '', '', 'REFFMN');  "
                                                   + " INSERT INTO[@MSS_SICER] VALUES(20, 20, 'PP', '', '', 'REFFME');  ";

                        }


                        Recordset rs = company.Value.GetBusinessObject(BoObjectTypes.BoRecordset);
                        rs.DoQuery(defaultValues);
                        Console.WriteLine("Estructura generada exitosamente para: " + company.Key);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(company.Key + "  -  " + ex);
                    }
                }

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadLine();
            }
        }

        public static void GenerateDBSchema(Company company)
        {
            try
            {
                DBSchema dBSchema = new UserModel().GetDBSchema();


                dBSchema.TableList.ForEach(x => SapMethodsHelper.RemoveTable(company, x.TableName));
                dBSchema.TableList.ForEach(x => SapMethodsHelper.CreateTable(company, x));
                dBSchema.FieldList.ForEach(x => SapMethodsHelper.CreateField(company, x));
                dBSchema.UDOList.ForEach(x => SapMethodsHelper.CreateUDO(company, x));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static Dictionary<string, SAPbobsCOM.Company> initializeConnections()
        {

            var companies = new Dictionary<string, SAPbobsCOM.Company>();
            System.Xml.Linq.XDocument connectionXML = System.Xml.Linq.XDocument.Load(AppDomain.CurrentDomain.BaseDirectory + CONNECTION_FILE);
            var xmlNodes = from header in connectionXML.Descendants("Company")
                           select new
                           {
                               CompanyCode = header.Element("DBCompany")?.Value,
                               Server = header.Element("Server")?.Value,
                               DBUser = header.Element("DBUser")?.Value,
                               DBPassword = header.Element("DBPassword")?.Value,
                               SBOUser = header.Element("SBOUser")?.Value,
                               SBOPassword = header.Element("SBOPassword")?.Value,
                               DbServerType = header.Element("DbServerType")?.Value
                           };
            if (xmlNodes != null)
                if (xmlNodes.ToList().Count <= 0)
                {
                    Console.WriteLine("No se encontró ninguna compañía en el archivo de conexion.");
                }


            foreach (var xmlNode in xmlNodes)
            {
                SAPbobsCOM.Company company = new SAPbobsCOM.Company();
                company.CompanyDB = xmlNode.CompanyCode;
                company.Server = xmlNode.Server;
                company.DbUserName = xmlNode.DBUser;
                company.DbPassword = xmlNode.DBPassword;
                company.UserName = xmlNode.SBOUser;
                company.Password = xmlNode.SBOPassword;
                company.language = SAPbobsCOM.BoSuppLangs.ln_Spanish;
                company.DbServerType = (SAPbobsCOM.BoDataServerTypes)Enum.Parse(typeof(SAPbobsCOM.BoDataServerTypes), xmlNode.DbServerType);
                if (company.Connect() == 0)
                {
                    companies.Add(company.CompanyDB, company);
                }
                else
                {
                    Console.WriteLine(xmlNode.CompanyCode);
                    Console.WriteLine(xmlNode.Server);
                    Console.WriteLine(xmlNode.DBUser);
                    Console.WriteLine(xmlNode.DBPassword);
                    Console.WriteLine(xmlNode.SBOUser);
                    Console.WriteLine(xmlNode.SBOPassword);
                    Console.WriteLine(xmlNode.DbServerType);
                    Console.WriteLine(company.CompanyDB + " - " + company.GetLastErrorDescription());
                }
            }

            return companies;
        }
    }
}
