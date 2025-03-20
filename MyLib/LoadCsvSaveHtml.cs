using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MyLib
{
    public class LoadCsvSaveHtml
    {
        public void LoadCsvData(string filePath, SalesHistory products)
        {
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    reader.ReadLine();

                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        string[] values = line.Split(',');

                        if (values.Length == 5)
                        {
                            try
                            {

                                string name = values[0];
                                string category = values[1];
                                decimal price = decimal.Parse(values[2], CultureInfo.InvariantCulture);
                                int residue = int.Parse(values[3]);
                                DateTime lastSell = DateTime.Parse(values[4]);


                                ProductInfo product = new ProductInfo(name, category, price, residue, lastSell);

                                products.AddSales(product);


                            }
                            catch (FormatException ex)
                            {
                                throw new Exception($"Ошибка формата в строке: {line}. Ошибка: {ex.Message}");
                            }
                            catch (Exception ex)
                            {
                                throw new Exception($"Непредвиденная ошибка в строке: {line}. Ошибка: {ex.Message}");
                            }
                        }
                        else
                        {
                            throw new Exception($"Неверное количество столбцов в строке: {line}.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при чтении файла: {ex.Message}");
            }
        }
    }
}



