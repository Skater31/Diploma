using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Threading.Tasks;
using Client.Connection;
using Client.EditWindows;
using Server_SIde.Models;
using Client.AddWindows;
using ClosedXML.Excel;
using System.IO;
using System.Globalization;
using OfficeIMO.Word;

namespace Client
{
    public partial class WorkShopWindow : Window
    {
        private readonly EquipmentConnection _equipmentConnection;
        private readonly FreeEquipmentConnection _freeEquipmentConnection;

        public WorkShopWindow()
        {
            _equipmentConnection = new EquipmentConnection();
            _freeEquipmentConnection = new FreeEquipmentConnection();

            InitializeComponent();

            LoadEquipment();
        }

        private void MainButtonAdd_Click(object sender, RoutedEventArgs e)
        {
           var tabItemName = ((TabItem)tabControl.SelectedItem).Name;

            switch (tabItemName)
            {
                case "gristMill":
                    new AddWindow(_equipmentConnection, 1).ShowDialog();
                    break;

                case "combine":
                    new AddWindow(_equipmentConnection, 2).ShowDialog();
                    break;

                case "mill":
                    new AddWindow(_equipmentConnection, 3).ShowDialog();
                    break;

                case "elevator":
                    new AddWindow(_equipmentConnection, 4).ShowDialog();
                    break;

                case "warehouseTHM":
                    new FreeEquipmentAddWindow(_freeEquipmentConnection, 1).ShowDialog();
                    break;

                case "warehouseBHM":
                    new FreeEquipmentAddWindow(_freeEquipmentConnection, 2).ShowDialog();
                    break;

                case "warehouseFP":
                    new FreeEquipmentAddWindow(_freeEquipmentConnection, 3).ShowDialog();
                    break;
            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            var tabItemName = ((TabItem)tabControl.SelectedItem).Name;

            switch (tabItemName)
            {
                case "gristMill":
                    if (listViewGristMill.SelectedItem != null)
                    {
                        _equipmentConnection.Delete((Equipment)listViewGristMill.SelectedItem);
                    }
                    break;

                case "combine":
                    if (listViewCombine.SelectedItem != null)
                    {
                        _equipmentConnection.Delete((Equipment)listViewCombine.SelectedItem);
                    }
                    break;

                case "mill":
                    if (listViewMill.SelectedItem != null)
                    {
                        _equipmentConnection.Delete((Equipment)listViewMill.SelectedItem);
                    }
                    break;

                case "elevator":
                    if (listViewElevator.SelectedItem != null)
                    {
                        _equipmentConnection.Delete((Equipment)listViewElevator.SelectedItem);
                    }
                    break;

                case "warehouseTHM":
                    if (listviewWarehouseTHM.SelectedItem != null)
                    {
                        _freeEquipmentConnection.Delete((FreeEquipment)listviewWarehouseTHM.SelectedItem);
                    }
                    break;

                case "warehouseBHM":
                    if (listviewWarehouseBHM.SelectedItem != null)
                    {
                        _freeEquipmentConnection.Delete((FreeEquipment)listviewWarehouseBHM.SelectedItem);
                    }
                    break;

                case "warehouseFP":
                    if (listviewWarehouseFP.SelectedItem != null)
                    {
                        _freeEquipmentConnection.Delete((FreeEquipment)listviewWarehouseFP.SelectedItem);
                    }
                    break;
            }
        }

        private void MainButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            var tabItemName = ((TabItem)tabControl.SelectedItem).Name;

            switch (tabItemName)
            {
                case "gristMill":
                    var equipGristMill = (Equipment)listViewGristMill.SelectedItem;

                    if (equipGristMill != null)
                    {
                        new EquipmentEditWindow(_equipmentConnection, equipGristMill.Id, equipGristMill.WorkshopId).ShowDialog();
                    }

                    break;

                case "combine":
                    var equipCombine = (Equipment)listViewCombine.SelectedItem;

                    if (equipCombine != null)
                    {
                        new EquipmentEditWindow(_equipmentConnection, equipCombine.Id, equipCombine.Id).ShowDialog();
                    }

                    break;

                case "mill":
                    var equipMill = (Equipment)listViewMill.SelectedItem;

                    if (equipMill != null)
                    {
                        new EquipmentEditWindow(_equipmentConnection, equipMill.Id, equipMill.WorkshopId).ShowDialog();
                    }

                    break;

                case "elevator":
                    var equipElevator = (Equipment)listViewElevator.SelectedItem;

                    if (equipElevator != null)
                    {
                        new EquipmentEditWindow(_equipmentConnection, equipElevator.Id, equipElevator.WorkshopId).ShowDialog();
                    }

                    break;

                case "warehouseTHM":
                    var freeEquipWarehouseTHM = (FreeEquipment)listviewWarehouseTHM.SelectedItem;

                    if (freeEquipWarehouseTHM != null)
                    {
                        new FreeEquipmentEditWindow(_freeEquipmentConnection, freeEquipWarehouseTHM.Id, freeEquipWarehouseTHM.WarehouseId).ShowDialog();
                    }

                    break;

                case "warehouseBHM":
                    var freeEquipWarehouseBHM = (FreeEquipment)listviewWarehouseBHM.SelectedItem;

                    if (freeEquipWarehouseBHM != null)
                    {
                        new FreeEquipmentEditWindow(_freeEquipmentConnection, freeEquipWarehouseBHM.Id, freeEquipWarehouseBHM.WarehouseId).ShowDialog();
                    }

                    break;

                case "warehouseFP":
                    var freeEquipWarehouseFP = (FreeEquipment)listviewWarehouseFP.SelectedItem;

                    if (freeEquipWarehouseFP != null)
                    {
                        new FreeEquipmentEditWindow(_freeEquipmentConnection, freeEquipWarehouseFP.Id, freeEquipWarehouseFP.WarehouseId).ShowDialog();
                    }

                    break;
            }
        }

        private async void ButtonRefresh_Click(object sender, RoutedEventArgs e)
        {
            var tabItemName = ((TabItem)tabControl.SelectedItem).Name;

            switch (tabItemName)
            {
                case "gristMill":
                    listViewGristMill.ItemsSource = await _equipmentConnection.GetAllEquipment(1);
                    break;

                case "combine":
                    listViewCombine.ItemsSource = await _equipmentConnection.GetAllEquipment(2);
                    break;

                case "mill":
                    listViewMill.ItemsSource = await _equipmentConnection.GetAllEquipment(3);
                    break;

                case "elevator":
                    listViewElevator.ItemsSource = await _equipmentConnection.GetAllEquipment(4);
                    break;

                case "warehouseTHM":
                    listviewWarehouseTHM.ItemsSource = await _freeEquipmentConnection.GetAllFreeEquipment(1);
                    break;

                case "warehouseBHM":
                    listviewWarehouseBHM.ItemsSource = await _freeEquipmentConnection.GetAllFreeEquipment(2);
                    break;

                case "warehouseFP":
                    listviewWarehouseFP.ItemsSource = await _freeEquipmentConnection.GetAllFreeEquipment(3);
                    break;
            }
        }

        private async void TextBoxFind_KeyDown(object sender, KeyEventArgs e)
        {
            var tabItemName = ((TabItem)tabControl.SelectedItem).Name;

            if (e.Key == Key.Enter && !string.IsNullOrEmpty(textBoxFind.Text))
            {
                switch (tabItemName)
                {
                    case "gristMill":
                        listViewGristMill.ItemsSource = await _equipmentConnection.Find(textBoxFind.Text, 1);
                        break;

                    case "combine":
                        listViewCombine.ItemsSource = await _equipmentConnection.Find(textBoxFind.Text, 2);
                        break;

                    case "mill":
                        listViewMill.ItemsSource = await _equipmentConnection.Find(textBoxFind.Text, 3);
                        break;

                    case "elevator":
                        listViewElevator.ItemsSource = await _equipmentConnection.Find(textBoxFind.Text, 4);
                        break;

                    case "warehouseTHM":
                        listviewWarehouseTHM.ItemsSource = await _freeEquipmentConnection.Find(textBoxFind.Text, 1);
                        break;

                    case "warehouseBHM":
                        listviewWarehouseBHM.ItemsSource = await _freeEquipmentConnection.Find(textBoxFind.Text, 2);
                        break;

                    case "warehouseFP":
                        listviewWarehouseFP.ItemsSource = await _freeEquipmentConnection.Find(textBoxFind.Text, 3);
                        break;
                }
            }

            if (e.Key == Key.Enter && string.IsNullOrEmpty(textBoxFind.Text))
            {
                switch (tabItemName)
                {
                    case "gristMill":
                        listViewGristMill.ItemsSource = await _equipmentConnection.GetAllEquipment(1);
                        break;

                    case "combine":
                        listViewCombine.ItemsSource = await _equipmentConnection.GetAllEquipment(2);
                        break;

                    case "mill":
                        listViewMill.ItemsSource = await _equipmentConnection.GetAllEquipment(3);
                        break;

                    case "elevator":
                        listViewElevator.ItemsSource = await _equipmentConnection.GetAllEquipment(4);
                        break;

                    case "warehouseTHM":
                        listviewWarehouseTHM.ItemsSource = await _freeEquipmentConnection.GetAllFreeEquipment(1);
                        break;

                    case "warehouseBHM":
                        listviewWarehouseBHM.ItemsSource = await _freeEquipmentConnection.GetAllFreeEquipment(2);
                        break;

                    case "warehouseFP":
                        listviewWarehouseFP.ItemsSource = await _freeEquipmentConnection.GetAllFreeEquipment(3);
                        break;
                }
            }
        }

        private void ButtonEmployees_Click(object sender, RoutedEventArgs e)
        {
            new EmployeeWindow(_freeEquipmentConnection).ShowDialog();
        }

        private async void LoadEquipment()
        {
            listViewGristMill.ItemsSource = await _equipmentConnection.GetAllEquipment(1);
            listViewCombine.ItemsSource = await _equipmentConnection.GetAllEquipment(2);
            listViewMill.ItemsSource = await _equipmentConnection.GetAllEquipment(3);
            listViewElevator.ItemsSource = await _equipmentConnection.GetAllEquipment(4);

            listviewWarehouseTHM.ItemsSource = await _freeEquipmentConnection.GetAllFreeEquipment(1);
            listviewWarehouseBHM.ItemsSource = await _freeEquipmentConnection.GetAllFreeEquipment(2);
            listviewWarehouseFP.ItemsSource = await _freeEquipmentConnection.GetAllFreeEquipment(3);
        }

        private void ButtonExcel_Click(object sender, RoutedEventArgs e)
        {
            using var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("myData");

            var tabItemName = ((TabItem)tabControl.SelectedItem).Name;

            switch (tabItemName)
            {
                case "gristMill":
                    ws.Cell(1, 1).InsertTable((IEnumerable<Equipment>)listViewGristMill.ItemsSource);
                    wb.SaveAs(@"C:\Users\Danila\Desktop\Сортовая мельница.xlsx");

                    MessageBox.Show("Данные добавлены в файл \'Сортовая мельница.xlsx\'");
                    break;

                case "combine":
                    ws.Cell(1, 1).InsertTable((IEnumerable<Equipment>)listViewCombine.ItemsSource);
                    wb.SaveAs(@"C:\Users\Danila\Desktop\Комбицех.xlsx");

                    MessageBox.Show("Данные добавлены в файл \'Комбицех.xlsx\'");
                    break;

                case "mill":
                    ws.Cell(1, 1).InsertTable((IEnumerable<Equipment>)listViewMill.ItemsSource);
                    wb.SaveAs(@"C:\Users\Danila\Desktop\Мельница.xlsx");

                    MessageBox.Show("Данные добавлены в файл \'Мельница.xlsx\'");
                    break;

                case "elevator":
                    ws.Cell(1, 1).InsertTable((IEnumerable<Equipment>)listViewElevator.ItemsSource);
                    wb.SaveAs(@"C:\Users\Danila\Desktop\Элеватор.xlsx");

                    MessageBox.Show("Данные добавлены в файл \'Элеватор.xlsx\'");
                    break;

                case "warehouseTHM":
                    ws.Cell(1, 1).InsertTable((IEnumerable<FreeEquipment>)listviewWarehouseTHM.ItemsSource);
                    wb.SaveAs(@"C:\Users\Danila\Desktop\Склад ТХМ.xlsx");

                    MessageBox.Show("Данные добавлены в файл \'Склад ТХМ.xlsx\'");
                    break;

                case "warehouseBHM":
                    ws.Cell(1, 1).InsertTable((IEnumerable<FreeEquipment>)listviewWarehouseBHM.ItemsSource);
                    wb.SaveAs(@"C:\Users\Danila\Desktop\Склад БХМ.xlsx");

                    MessageBox.Show("Данные добавлены в файл \'Склад БХМ.xlsx\'");
                    break;

                case "warehouseFP":
                    ws.Cell(1, 1).InsertTable((IEnumerable<FreeEquipment>)listviewWarehouseFP.ItemsSource);
                    wb.SaveAs(@"C:\Users\Danila\Desktop\Склад готовой продукции.xlsx");

                    MessageBox.Show("Данные добавлены в файл \'Склад готовой продукции.xlsx\'");
                    break;
            }
        }

        private void ButtonWord_Click(object sender, RoutedEventArgs e)
        {
            var tabItemName = ((TabItem)tabControl.SelectedItem).Name;

            switch (tabItemName)
            {
                case "gristMill":
                    EquipmentToWord(@"C:\Users\Danila\Desktop\Сортовая мельница.docx", 
                        (List<Equipment>)listViewGristMill.ItemsSource);

                    MessageBox.Show("Данные добавлены в файл \'Сортовая мельница.docx\'");
                    break;

                case "combine":
                    EquipmentToWord(@"C:\Users\Danila\Desktop\Комбицех.docx",
                        (List<Equipment>)listViewCombine.ItemsSource);

                    MessageBox.Show("Данные добавлены в файл \'Комбицех.docx\'");
                    break;

                case "mill":
                    EquipmentToWord(@"C:\Users\Danila\Desktop\Мельница.docx",
                        (List<Equipment>)listViewMill.ItemsSource);

                    MessageBox.Show("Данные добавлены в файл \'Мельница.docx\'");
                    break;

                case "elevator":
                    EquipmentToWord(@"C:\Users\Danila\Desktop\Элеватор.docx",
                        (List<Equipment>)listViewElevator.ItemsSource);

                    MessageBox.Show("Данные добавлены в файл \'Элеватор.docx\'");
                    break;

                case "warehouseTHM":
                    FreeEquipmentToWord(@"C:\Users\Danila\Desktop\Склад ТХМ.docx",
                        (List<FreeEquipment>)listviewWarehouseTHM.ItemsSource);

                    MessageBox.Show("Данные добавлены в файл \'Склад ТХМ.docx\'");
                    break;

                case "warehouseBHM":
                    FreeEquipmentToWord(@"C:\Users\Danila\Desktop\Склад БХМ.docx",
                        (List<FreeEquipment>)listviewWarehouseBHM.ItemsSource);

                    MessageBox.Show("Данные добавлены в файл \'Склад БХМ.docx\'");
                    break;

                case "warehouseFP":
                    FreeEquipmentToWord(@"C:\Users\Danila\Desktop\Склад готовой продукции.docx",
                        (List<FreeEquipment>)listviewWarehouseFP.ItemsSource);

                    MessageBox.Show("Данные добавлены в файл \'Склад готовой продукции.docx\'");
                    break;
            }
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void EquipmentToWord(string filePath, List<Equipment> equipmentList)
        {
            using var document = WordDocument.Create(filePath);

            foreach (var equipment in equipmentList)
            {
                var equip = $"Id: {equipment.Id}\n" +
                    $"Name: {equipment.Name}\n" +
                    $"Inv. number: {equipment.InventoryNumber}\n" +
                    $"Price: {equipment.Price}\n" +
                    $"YearOfInstalation: {equipment.YearOfInstalation}\n" +
                    $"MarkId: {equipment.MarkId}\n" +
                    $"WorkshopId: {equipment.WorkshopId}\n";

                document.AddParagraph(equip);
            }

            document.Save();
        }

        private void FreeEquipmentToWord(string filePath, List<FreeEquipment> freeEquipmentList)
        {
            using var document = WordDocument.Create(filePath);

            foreach (var freeEquipment in freeEquipmentList)
            {
                var freeEquip = $"Id: {freeEquipment.Id}\n" +
                    $"Name: {freeEquipment.Name}\n" +
                    $"Inv. number: {freeEquipment.InventoryNumber}\n" +
                    $"Price: {freeEquipment.Price}\n" +
                    $"MarkId: {freeEquipment.MarkId}\n" +
                    $"WarehouseId: {freeEquipment.WarehouseId}\n" +
                    $"EmployeeId: {freeEquipment.EmployeeId}\n" +
                    $"SupplierId: {freeEquipment.SupplierId}\n";

                document.AddParagraph(freeEquip);
            }

            document.Save();
        }
    }
}
