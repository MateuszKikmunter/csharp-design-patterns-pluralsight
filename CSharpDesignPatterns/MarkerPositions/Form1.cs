using System;
using System.Windows.Forms;

namespace MarkerPositions
{
    public partial class Form1 : Form
    {
        private readonly MarkerMediator _mediator = new MarkerMediator();

        private Button addButton;

        public Form1()
        {
            InitializeComponent();
            addButton = new Button();
            addButton.Click += OnAddClick;
            addButton.Text = "Add Marker";
            addButton.Dock = DockStyle.Bottom;
            Controls.Add(addButton);
        }

        private void OnAddClick(object sender, EventArgs e)
        {
            var marker = _mediator.CreateMarker();
            Controls.Add(marker);
        }
    }
}
