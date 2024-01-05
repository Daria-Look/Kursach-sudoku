using System.Data;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {        
        public Form1()
        {
            InitializeComponent();
            GenerateMap();
        }
                
        public void GenerateMap() //�������� ������� ����
        {
            for (int i = 0; i < 8; i++) //������ ������ ��� ����
            {
                dataGridView1.Rows.Add();
            }

            /* �������� ���� */
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.LightCyan;
                }
            }

            for (int i = 0; i < 9; i++)
            {
                for (int j = 3; j < 6; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.LightBlue;
                    dataGridView1.Rows[j].Cells[i].Style.BackColor = Color.LightBlue;
                }
            }

            for (int i = 3; i < 6; i++)
            {
                for (int j = 3; j < 6; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.LightCyan;
                    //DGV1.Rows[j].Cells[i].Style.BackColor = Color.LightBlue;
                }
            }
            /* ����� �������� */

        }
        
        private void �������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //������ ���������� ������ ������� ���������
            �������ToolStripMenuItem.Checked = true;
            �������ToolStripMenuItem.Checked = false;
            ������ToolStripMenuItem1.Checked = false;
        }

        private void �������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //������ ���������� ������ ������� ���������
            �������ToolStripMenuItem.Checked = false;
            �������ToolStripMenuItem.Checked = true;
            ������ToolStripMenuItem1.Checked= false;
        }

        private void ������ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //������ ���������� ������ ������� ���������
            �������ToolStripMenuItem.Checked = false;
            �������ToolStripMenuItem.Checked = false;
            ������ToolStripMenuItem1.Checked = true; //���������� �� ���������
        }

        

        private void ���������ToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            dataGridView1.Rows.Clear(); //������� ���� ��� ��������� ������ ������
            GenerateMap(); //���������� �����
            Random r = new Random();
            int helpCells = 0;

            /* ����������� ����� */
            if (�������ToolStripMenuItem.Checked)
            {
                helpCells = r.Next(4, 6); //����� ������ � �������������� �������
                
            }
            else if (�������ToolStripMenuItem.Checked)
            {
                helpCells = r.Next(5, 7); //����� ������ � �������������� �������

            }
            else if (������ToolStripMenuItem1.Checked)
            {
                helpCells = r.Next(6, 8); //����� ������ � �������������� �������

            }    
            /* ����� ����������� */
        }
    }
}
