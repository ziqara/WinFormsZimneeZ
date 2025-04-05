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
        public SalesHistory LoadCsvData(string filePath, SalesHistory products)
        {
            try
            {
                products.ClearSales(); // Очищаем существующие данные

                using (StreamReader reader = new StreamReader(filePath))
                {
                    reader.ReadLine(); // Пропускаем заголовок

                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        string[] values = line.Split(',');

                        if (values.Length == 6)
                        {
                            try
                            {
                                string name = values[0];
                                string category = values[1];
                                decimal price = decimal.Parse(values[2], CultureInfo.InvariantCulture);
                                int quantitysold = int.Parse(values[3]);
                                int residue = int.Parse(values[4]);
                                DateTime lastSell = DateTime.Parse(values[5]);

                                ProductInfo product = new ProductInfo(name, category, price, quantitysold, residue, lastSell);
                                products.AddSales(product);
                            }
                            catch (FormatException ex)
                            {
                                throw new Exception($"Ошибка формата в строке: {line}. Ошибка: {ex.Message}");
                            }
                        }
                        else
                        {
                            throw new Exception($"Неверное количество столбцов в строке: {line}.");
                        }
                    }
                }
                return products;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при чтении файла: {ex.Message}");
            }
        }

        public static void SaveDataGridViewToHtml(DataGridView dataGridView, string filePath)
        {
            StringBuilder sb = new StringBuilder();

            // Начинаем HTML документ
            sb.Append("<!DOCTYPE html>\r\n");
            sb.Append("<html>\r\n");
            sb.Append("<head>\r\n");
            sb.Append("<title>DataGridView Data</title>\r\n");
            sb.Append("<style>\r\n");
            sb.Append("table { border-collapse: collapse; width: 100%; }\r\n");
            sb.Append("th, td { border: 1px solid black; padding: 8px; text-align: left; }\r\n");
            sb.Append("th { background-color: #f2f2f2; }\r\n");
            sb.Append("</style>\r\n");
            sb.Append("</head>\r\n");
            sb.Append("<body>\r\n");

            // Начинаем таблицу
            sb.Append("<table>\r\n");

            // Заголовки таблицы
            sb.Append("<thead>\r\n");
            sb.Append("<tr>\r\n");
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                sb.Append($"<th>{column.HeaderText}</th>\r\n");
            }
            sb.Append("</tr>\r\n");
            sb.Append("</thead>\r\n");

            // Тело таблицы
            sb.Append("<tbody>\r\n");
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                sb.Append("<tr>\r\n");
                foreach (DataGridViewCell cell in row.Cells)
                {
                    object cellValue = cell.Value;
                    string cellText = (cellValue != null) ? cellValue.ToString() : string.Empty;
                    sb.Append($"<td>{cellText}</td>\r\n");
                }
                sb.Append("</tr>\r\n");
            }
            sb.Append("</tbody>\r\n");

            // Заканчиваем таблицу
            sb.Append("</table>\r\n");

            // Заканчиваем HTML документ
            sb.Append("</body>\r\n");
            sb.Append("</html>\r\n");

            // Записываем в файл
            try
            {
                File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving to file: {ex.Message}");
            }
        }
    }
}



