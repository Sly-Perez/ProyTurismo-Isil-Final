using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ProyTurismo_BE
{
    public class EmpleadoBE
    {



        public int ID_Empleado { get; set; }
        public string Nom_Emp { get; set; }
        public string Ape_Emp { get; set; }
        public string Dni_Emp { get; set; }
        public string Tel_Emp { get; set; }
        public string Email_Emp { get; set; }
        public string Rol_Emp { get; set; }
        public int? Supervisor_ID { get; set; }
        public DateTime? Fec_Reg { get; set; }

        public DateTime? Fec_ult_mod { get; set; }

        public string Estado { get; set; }


        public EmpleadoBE()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }

        public void ExportarExcel(List<EmpleadoBE> empleados)
        {
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Empleados");

                worksheet.Cells[1, 1].Value = "ID Empleado";
                worksheet.Cells[1, 2].Value = "Nombre";
                worksheet.Cells[1, 3].Value = "Apellido";
                worksheet.Cells[1, 4].Value = "DNI";
                worksheet.Cells[1, 5].Value = "Teléfono";
                worksheet.Cells[1, 6].Value = "Email";
                worksheet.Cells[1, 7].Value = "Rol";
                worksheet.Cells[1, 8].Value = "Supervisor ID";
                worksheet.Cells[1, 9].Value = "Fecha Registro";
                worksheet.Cells[1, 10].Value = "Fecha Última Modificación";
                worksheet.Cells[1, 11].Value = "Estado";

                int row = 2; 
                foreach (var empleado in empleados)
                {
                    worksheet.Cells[row, 1].Value = empleado.ID_Empleado;
                    worksheet.Cells[row, 2].Value = empleado.Nom_Emp;
                    worksheet.Cells[row, 3].Value = empleado.Ape_Emp;
                    worksheet.Cells[row, 4].Value = empleado.Dni_Emp;
                    worksheet.Cells[row, 5].Value = empleado.Tel_Emp;
                    worksheet.Cells[row, 6].Value = empleado.Email_Emp;
                    worksheet.Cells[row, 7].Value = empleado.Rol_Emp;
                    worksheet.Cells[row, 8].Value = empleado.Supervisor_ID;
                    worksheet.Cells[row, 9].Value = empleado.Fec_Reg;
                    worksheet.Cells[row, 10].Value = empleado.Fec_ult_mod;
                    worksheet.Cells[row, 11].Value = empleado.Estado;
                    row++; 
                }

                var tempFolder = Path.GetTempPath(); 
                var filePath = Path.Combine(tempFolder, "Empleados.xlsx");

                var fileInfo = new FileInfo(filePath);
                package.SaveAs(fileInfo);

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=Empleados.xlsx");
                HttpContext.Current.Response.TransmitFile(filePath);
                HttpContext.Current.Response.End();
            }
        }
    }
}
