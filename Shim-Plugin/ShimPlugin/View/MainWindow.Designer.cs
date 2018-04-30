using System;
using System.Windows.Forms;
namespace ShimPlugin
{
    partial class MainWindow
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.BuildButton = new System.Windows.Forms.Button();
            this.InnerRadiusTextBox = new System.Windows.Forms.TextBox();
            this.OuterRadiusTextBox = new System.Windows.Forms.TextBox();
            this.HeightTextBox = new System.Windows.Forms.TextBox();
            this.InnerFilletTextBox = new System.Windows.Forms.TextBox();
            this.OuterFilletTextBox = new System.Windows.Forms.TextBox();
            this.GrooveRadiusTextBox = new System.Windows.Forms.TextBox();
            this.InnerRadiusLabel = new System.Windows.Forms.Label();
            this.OuterRadiusLabel = new System.Windows.Forms.Label();
            this.HeightLabel = new System.Windows.Forms.Label();
            this.InnerFilletLabel = new System.Windows.Forms.Label();
            this.OuterFilletLabel = new System.Windows.Forms.Label();
            this.GrooveRadiusLabel = new System.Windows.Forms.Label();
            this.GrooveCheckBox = new System.Windows.Forms.CheckBox();
            this.CloseButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BuildButton
            // 
            this.BuildButton.Location = new System.Drawing.Point(202, 169);
            this.BuildButton.Name = "BuildButton";
            this.BuildButton.Size = new System.Drawing.Size(101, 23);
            this.BuildButton.TabIndex = 0;
            this.BuildButton.Text = "Построить";
            this.BuildButton.UseVisualStyleBackColor = true;
            this.BuildButton.Click += new System.EventHandler(this.BuildButton_Click);
            // 
            // InnerRadiusTextBox
            // 
            this.InnerRadiusTextBox.Location = new System.Drawing.Point(202, 12);
            this.InnerRadiusTextBox.Name = "InnerRadiusTextBox";
            this.InnerRadiusTextBox.Size = new System.Drawing.Size(100, 20);
            this.InnerRadiusTextBox.TabIndex = 1;
            this.InnerRadiusTextBox.TextChanged += new System.EventHandler(this.ChangeToBackColor);
            this.InnerRadiusTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IsNumberOrDotPressed);
            this.InnerRadiusTextBox.Leave += new System.EventHandler(this.TextBoxValidate);
            // 
            // OuterRadiusTextBox
            // 
            this.OuterRadiusTextBox.Location = new System.Drawing.Point(202, 37);
            this.OuterRadiusTextBox.Name = "OuterRadiusTextBox";
            this.OuterRadiusTextBox.Size = new System.Drawing.Size(100, 20);
            this.OuterRadiusTextBox.TabIndex = 2;
            this.OuterRadiusTextBox.TextChanged += new System.EventHandler(this.ChangeToBackColor);
            this.OuterRadiusTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IsNumberOrDotPressed);
            this.OuterRadiusTextBox.Leave += new System.EventHandler(this.TextBoxValidate);
            // 
            // HeightTextBox
            // 
            this.HeightTextBox.Location = new System.Drawing.Point(202, 62);
            this.HeightTextBox.Name = "HeightTextBox";
            this.HeightTextBox.Size = new System.Drawing.Size(100, 20);
            this.HeightTextBox.TabIndex = 3;
            this.HeightTextBox.TextChanged += new System.EventHandler(this.ChangeToBackColor);
            this.HeightTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IsNumberOrDotPressed);
            this.HeightTextBox.Leave += new System.EventHandler(this.TextBoxValidate);
            // 
            // InnerFilletTextBox
            // 
            this.InnerFilletTextBox.Location = new System.Drawing.Point(202, 87);
            this.InnerFilletTextBox.Name = "InnerFilletTextBox";
            this.InnerFilletTextBox.Size = new System.Drawing.Size(100, 20);
            this.InnerFilletTextBox.TabIndex = 4;
            this.InnerFilletTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IsNumberOrDotPressed);
            this.InnerFilletTextBox.Leave += new System.EventHandler(this.TextBoxValidate);
            // 
            // OuterFilletTextBox
            // 
            this.OuterFilletTextBox.Location = new System.Drawing.Point(202, 112);
            this.OuterFilletTextBox.Name = "OuterFilletTextBox";
            this.OuterFilletTextBox.Size = new System.Drawing.Size(100, 20);
            this.OuterFilletTextBox.TabIndex = 5;
            this.OuterFilletTextBox.TextChanged += new System.EventHandler(this.ChangeToBackColor);
            this.OuterFilletTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IsNumberOrDotPressed);
            // 
            // GrooveRadiusTextBox
            // 
            this.GrooveRadiusTextBox.Enabled = false;
            this.GrooveRadiusTextBox.Location = new System.Drawing.Point(202, 138);
            this.GrooveRadiusTextBox.Name = "GrooveRadiusTextBox";
            this.GrooveRadiusTextBox.Size = new System.Drawing.Size(100, 20);
            this.GrooveRadiusTextBox.TabIndex = 6;
            this.GrooveRadiusTextBox.TextChanged += new System.EventHandler(this.ChangeToBackColor);
            this.GrooveRadiusTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IsNumberOrDotPressed);
            this.GrooveRadiusTextBox.Leave += new System.EventHandler(this.TextBoxValidate);
            // 
            // InnerRadiusLabel
            // 
            this.InnerRadiusLabel.AutoSize = true;
            this.InnerRadiusLabel.Location = new System.Drawing.Point(12, 15);
            this.InnerRadiusLabel.Name = "InnerRadiusLabel";
            this.InnerRadiusLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.InnerRadiusLabel.Size = new System.Drawing.Size(142, 13);
            this.InnerRadiusLabel.TabIndex = 8;
            this.InnerRadiusLabel.Text = "Радиус внутреннего обода";
            // 
            // OuterRadiusLabel
            // 
            this.OuterRadiusLabel.AutoSize = true;
            this.OuterRadiusLabel.Location = new System.Drawing.Point(12, 40);
            this.OuterRadiusLabel.Name = "OuterRadiusLabel";
            this.OuterRadiusLabel.Size = new System.Drawing.Size(128, 13);
            this.OuterRadiusLabel.TabIndex = 9;
            this.OuterRadiusLabel.Text = "Радиус внешнего обода";
            // 
            // HeightLabel
            // 
            this.HeightLabel.AutoSize = true;
            this.HeightLabel.Location = new System.Drawing.Point(12, 65);
            this.HeightLabel.Name = "HeightLabel";
            this.HeightLabel.Size = new System.Drawing.Size(45, 13);
            this.HeightLabel.TabIndex = 10;
            this.HeightLabel.Text = "Высота";
            // 
            // InnerFilletLabel
            // 
            this.InnerFilletLabel.AutoSize = true;
            this.InnerFilletLabel.Location = new System.Drawing.Point(12, 90);
            this.InnerFilletLabel.Name = "InnerFilletLabel";
            this.InnerFilletLabel.Size = new System.Drawing.Size(176, 13);
            this.InnerFilletLabel.TabIndex = 11;
            this.InnerFilletLabel.Text = "Радиус внутрненнего скругления";
            // 
            // OuterFilletLabel
            // 
            this.OuterFilletLabel.AutoSize = true;
            this.OuterFilletLabel.Location = new System.Drawing.Point(12, 115);
            this.OuterFilletLabel.Name = "OuterFilletLabel";
            this.OuterFilletLabel.Size = new System.Drawing.Size(156, 13);
            this.OuterFilletLabel.TabIndex = 12;
            this.OuterFilletLabel.Text = "Радиус внешнего скругления";
            // 
            // GrooveRadiusLabel
            // 
            this.GrooveRadiusLabel.AutoSize = true;
            this.GrooveRadiusLabel.Enabled = false;
            this.GrooveRadiusLabel.Location = new System.Drawing.Point(98, 141);
            this.GrooveRadiusLabel.Name = "GrooveRadiusLabel";
            this.GrooveRadiusLabel.Size = new System.Drawing.Size(70, 13);
            this.GrooveRadiusLabel.TabIndex = 13;
            this.GrooveRadiusLabel.Text = "Радиус паза";
            // 
            // GrooveCheckBox
            // 
            this.GrooveCheckBox.AutoSize = true;
            this.GrooveCheckBox.Location = new System.Drawing.Point(15, 140);
            this.GrooveCheckBox.Name = "GrooveCheckBox";
            this.GrooveCheckBox.Size = new System.Drawing.Size(46, 17);
            this.GrooveCheckBox.TabIndex = 14;
            this.GrooveCheckBox.Text = "Паз";
            this.GrooveCheckBox.UseVisualStyleBackColor = true;
            this.GrooveCheckBox.CheckedChanged += new System.EventHandler(this.GrooveCheckBox_CheckedChanged);
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(12, 169);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(101, 23);
            this.CloseButton.TabIndex = 15;
            this.CloseButton.Text = "Выход";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 204);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.GrooveCheckBox);
            this.Controls.Add(this.GrooveRadiusLabel);
            this.Controls.Add(this.OuterFilletLabel);
            this.Controls.Add(this.InnerFilletLabel);
            this.Controls.Add(this.HeightLabel);
            this.Controls.Add(this.OuterRadiusLabel);
            this.Controls.Add(this.InnerRadiusLabel);
            this.Controls.Add(this.GrooveRadiusTextBox);
            this.Controls.Add(this.OuterFilletTextBox);
            this.Controls.Add(this.InnerFilletTextBox);
            this.Controls.Add(this.HeightTextBox);
            this.Controls.Add(this.OuterRadiusTextBox);
            this.Controls.Add(this.InnerRadiusTextBox);
            this.Controls.Add(this.BuildButton);
            this.Name = "MainWindow";
            this.Text = "Shim Kompas Plug-in";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BuildButton;
        private System.Windows.Forms.TextBox InnerRadiusTextBox;
        private System.Windows.Forms.TextBox OuterRadiusTextBox;
        private System.Windows.Forms.TextBox HeightTextBox;
        private System.Windows.Forms.TextBox InnerFilletTextBox;
        private System.Windows.Forms.TextBox OuterFilletTextBox;
        private System.Windows.Forms.TextBox GrooveRadiusTextBox;
        private System.Windows.Forms.Label InnerRadiusLabel;
        private System.Windows.Forms.Label OuterRadiusLabel;
        private System.Windows.Forms.Label HeightLabel;
        private System.Windows.Forms.Label InnerFilletLabel;
        private System.Windows.Forms.Label OuterFilletLabel;
        private System.Windows.Forms.Label GrooveRadiusLabel;
        private System.Windows.Forms.CheckBox GrooveCheckBox;
        private Button CloseButton;
    }
}

