using System.Collections.Generic;
using System.Windows.Forms;

using ShimPlugin.Model;
using System;
using ShimPlugin.Model.Exceptions;
using System.Drawing;

namespace ShimPlugin
{
    public partial class MainWindow : Form
    {
        // Словарь привязки текстбоксов и лейблов
        private Dictionary<TextBox, Label> _textBoxLabelBindDictionary = 
            new Dictionary<TextBox, Label>();

        // Объект для связи с KOMPAS
        private KompasWrapper _kompasWrapper = new KompasWrapper();

        public MainWindow()
        {
            InitializeComponent();
            InitializeBindDictionary();
        }

        /// <summary>
        /// Заполняет словарь привязки текстбоксов и лейблов
        /// </summary>
        private void InitializeBindDictionary()
        {
            _textBoxLabelBindDictionary.Add(InnerRadiusTextBox,
                InnerRadiusLabel);
            _textBoxLabelBindDictionary.Add(OuterRadiusTextBox,
                OuterRadiusLabel);
            _textBoxLabelBindDictionary.Add(HeightTextBox,
                HeightLabel);
            _textBoxLabelBindDictionary.Add(InnerFilletTextBox,
                InnerFilletLabel);
            _textBoxLabelBindDictionary.Add(OuterFilletTextBox,
                OuterFilletLabel);
            _textBoxLabelBindDictionary.Add(GrooveRadiusTextBox,
                GrooveRadiusLabel);
        }

        /// <summary>
        /// Клик по кнопке "построить"
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Параметры события</param>
        private void BuildButton_Click(object sender, EventArgs e)
        {
            ShimSettings shimSettings = null;
            shimSettings = InitializeShimSettings(shimSettings);

            if (shimSettings != null)
            {
                _kompasWrapper.StartKompas();
                _kompasWrapper.BuildShim(shimSettings);
            }
        }

        /// <summary>
        /// Разбирает введеный в форму бред и пытается 
        /// превратить в ShimSettings
        /// </summary>
        /// <param name="shimSettings"></param>
        /// <returns>Возвращает параметры шайбы</returns>
        private ShimSettings InitializeShimSettings(ShimSettings shimSettings)
        {
            try
            {
                double innerRadius = 
                    Convert.ToDouble(InnerRadiusTextBox.Text);
                double outerRadius = 
                    Convert.ToDouble(OuterRadiusTextBox.Text);
                double height = 
                    Convert.ToDouble(HeightTextBox.Text);
                double innerFillet = 
                    Convert.ToDouble(InnerFilletTextBox.Text);
                double outerFillet = 
                    Convert.ToDouble(OuterFilletTextBox.Text);
                double grooveRadius = 
                    GrooveCheckBox.Checked ? 
                    Convert.ToDouble(GrooveRadiusTextBox.Text) : 0;

                shimSettings = new ShimSettings(innerRadius, outerRadius,
                    height, innerFillet, outerFillet, grooveRadius);
            }
            catch (InnerRadiusException exception)
            {
                ShowErrorMessage(InnerRadiusLabel, exception.Message);
            }
            catch (OuterRadiusException exception)
            {
                ShowErrorMessage(OuterRadiusLabel, exception.Message);
            }
            catch (HeightException exception)
            {
                ShowErrorMessage(HeightLabel, exception.Message);
            }
            catch (FilletException exception)
            {
                ShowErrorMessage(InnerFilletLabel, exception.Message);
            }
            catch (GrooveRadiusException exception)
            {
                ShowErrorMessage(GrooveRadiusLabel, exception.Message);
            }
            catch (FormatException)
            {
                ShowErrorMessage(null,
                    "Заполните все параметры!");
            }

            return shimSettings;
        }

        /// <summary>
        /// Событие проверяющее чтобы текстбокс 
        /// содержал максимум один знак разделения (точка, запятая)
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Параметры события</param>
        private void IsNumberOrDotPressed(object sender, KeyPressEventArgs e)
        {
            // Пропускаем символы из строки

            e.Handled = "1234567890,.\b".IndexOf(e.KeyChar) == -1;

            // Запрещаем повтор запятых и точек

            TextBox textBox = (TextBox)sender;
            bool TextBoxHavePunctuation =
                textBox.Text.IndexOf('.') != -1
                || textBox.Text.IndexOf(',') != -1;
            bool isPunctuation = Char.IsPunctuation(e.KeyChar);
            if (isPunctuation && TextBoxHavePunctuation)
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Вывод сообщения об ошибке и подсветка лейбла 
        /// связанного с этой ошибкой
        /// </summary>
        /// <param name="label">Подсвечиваемый лейбл</param>
        /// <param name="message">Сообщение которое требуется вывести</param>
        private void ShowErrorMessage(Label label, string message)
        {
            // Если лейбл есть - подсветим его
            bool needToHighlight = label != null;
            if (needToHighlight)
            {
                label.BackColor = Color.Red;
            }

            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        /// Возвращение исходного цвета для лейбла привязанного к текстбоксу
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Параметры события</param>
        private void ChangeToBackColor(object sender, EventArgs e)
        {
            _textBoxLabelBindDictionary[(TextBox)sender].BackColor =
                Color.Transparent;
        }

        /// <summary>
        /// Проверка текстбокса на неверные 
        /// значения (пустота или просто точка/запятая)
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Параметры события</param>
        private void TextBoxValidate(object sender, EventArgs e)
        {
            TextBox textBox = ((TextBox)sender);
            bool invalidValue = textBox.Text == ""
                || textBox.Text == "."
                || textBox.Text == ",";
            if (invalidValue)
            {
                ShowErrorMessage(_textBoxLabelBindDictionary[textBox],
                    "Данный параметр содержит неверное значение.");
                textBox.Focus();
            }
        }

        /// <summary>
        /// Обработчик нажатия на галочку "Паз".
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Параметры события</param>
        private void GrooveCheckBox_CheckedChanged(object sender, 
            EventArgs e)
        {
            GrooveRadiusLabel.Enabled = GrooveCheckBox.Checked;
            GrooveRadiusTextBox.Enabled = GrooveCheckBox.Checked;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
