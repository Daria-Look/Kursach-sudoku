using System.CodeDom.Compiler;
using System.Data;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        static int[,] grid = new int[9, 9];
        static bool[,] zeroGrid = new bool[9, 9];
        static Random ran = new Random();
        public Form1()
        {
            InitializeComponent();
            GenerateMap();
        }

        private void GenerateMap() //�������� ������� ����
        {
            for (int i = 0; i < 8; i++) //������ ������ ��� ����
            {
                dataGridView1.Rows.Add(); //��������� ������ � dataGridView1
            }
            
            /* ������ �������� ���� */
            for (int i = 0; i < 9; i++) //����� ���������� ������������ �������� �����
            {
                DataGridViewColumn column = dataGridView1.Columns[i]; //����� i-�� �������
                column.Width = (int)(dataGridView1.Width / 9f); //������� ������������ dataGridView1 �� 9 ������
                DataGridViewRow row = dataGridView1.Rows[i]; // �� ����
                row.Height = (int)(dataGridView1.Height / 9f);
            }
            dataGridView1.Width = dataGridView1.Columns[1].Width * 9; //��������� ������
            /* ������ ���� ������ */

            /* �������� ���� */
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.LightCyan; //������ � �������
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
                }
            }
            /* ����� �������� */
        }

        private void BasicFill() //������� ������� ����. �� ��� ��������� ���������. ��������� ������
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    grid[i, j] = ((i * 3 + i / 3 + j) % 9 + 1);  //������� ����������
                }
            }
        }

        private void Filling()
        {
            int rows = dataGridView1.RowCount;
            int cols = dataGridView1.ColumnCount;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (grid[i, j] != -1) //���� ������ �� ������
                    {
                        dataGridView1.Rows[i].Cells[j].Value = grid[i, j];
                        dataGridView1.Rows[i].Cells[j].Style.ForeColor = Color.DarkViolet; //���� ���� �� ���������
                    }
                    else continue; //�������� �����
                }
            }
        }

        private static void Deleting(int delete0)
        {
            for (int k = 0; k < delete0; k++)
            {
                int i = ran.Next() % 9; //��������� ����� ���������� � ��������� ������� �� ������� �� 9
                int j = ran.Next() % 9;
                if (!zeroGrid[i, j]) //�������� �� ������ ������
                {
                    grid[i, j] = -1;
                    zeroGrid[i, j] = !zeroGrid[i, j];
                }
                else { k--; }
            }
        }

        /* ������� �� ������� */
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
            ������ToolStripMenuItem1.Checked = false;
        }

        private void ������ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //������ ���������� ������ ������� ���������
            �������ToolStripMenuItem.Checked = false;
            �������ToolStripMenuItem.Checked = false;
            ������ToolStripMenuItem1.Checked = true; //���������� �� ���������
        }
        /* ����������� ������� */

        static void Transponing() //����������������. ���������� �� ��������
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    int tmp = grid[i, j];
                    grid[i, j] = grid[j, i];
                    grid[j, i] = tmp;

                    bool tmp1 = zeroGrid[i, j];
                    zeroGrid[i, j] = zeroGrid[j, i];
                    zeroGrid[j, i] = tmp1;
                }
            }
        }

        static void SwapRows() //������ � ������� �������� �������
        {
            //������ ������
            int first = ran.Next(1, 3);
            int second = ran.Next(1, 3);

            //������ ������
            int third = ran.Next(4, 6);
            int fourth = ran.Next(4, 6);

            //������ ������
            int fifth = ran.Next(7, 9);
            int sixth = ran.Next(7, 9);

            //�������� ������������
            for (int k = 0; k < 9; k++)
            {
                int tmp = grid[first - 1, k];
                grid[first - 1, k] = grid[second - 1, k];
                grid[second - 1, k] = tmp;
            }
            for (int k = 0; k < 9; k++)
            {
                int tmp = grid[third - 1, k];
                grid[third - 1, k] = grid[fourth - 1, k];
                grid[fourth - 1, k] = tmp;
            }
            for (int k = 0; k < 9; k++)
            {
                int tmp = grid[fifth - 1, k];
                grid[fifth - 1, k] = grid[sixth - 1, k];
                grid[sixth - 1, k] = tmp;
            }

        }
        static void SwapColumns() //������ ��������
        { //�������������, ��� �������� ������ ������� � �������
            Transponing(); //���������� ������� � ������
            SwapRows(); //������������� �����
            Transponing(); //����������������
        }

        private void ���������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Visible = false;

            //�������� ������ ����
            grid = new int[9, 9];
            zeroGrid = new bool[9, 9];

            dataGridView1.Rows.Clear(); //������� ���� ��� ��������� ������ ������

            GenerateMap(); //���������� �����
            BasicFill();

            int mixx = ran.Next(10, 100); //�������� ����� �������������. ����� �� 40. � �� 50
            //�������������, ��� ���� ������� (�� ��� ����)
            for (int i = 0; i < mixx; i++)
            {
                Transponing();
                SwapRows();
                SwapColumns();
            }

            /* ������� ����� */
            if (�������ToolStripMenuItem.Checked)
            {
                //������� ��������� �������� � ������� ��������
                int delete1 = ran.Next(56, 61);
                Deleting(delete1);
            }
            else if (�������ToolStripMenuItem.Checked)
            {
                //������� ��������� �������� � ������� ��������
                int delete2 = ran.Next(51, 56);
                Deleting(delete2);
            }
            else if (������ToolStripMenuItem1.Checked)
            {
                //������� ��������� �������� � ������� ��������
                int delete3 = ran.Next(46, 51);
                Deleting(delete3);
            }
            Filling();
            /* ����� ����������� */
        }

        private int ColoringFore(int i, int j, int allCells) //��������� ������
        {
            dataGridView1.Rows[i].Cells[j].Style.ForeColor = Color.Red; //������ �������
            allCells = 0; //�� ������� �����, �� ������� ������
            pon.Visible = true; //������ ������� ������
            return (allCells);
        }

        private int CheckingMap(int prov)
        {
            int rows = 9; //���-�� �����
            int cols = 9; //���-�� ��������
            int allCells = 0; //������� ��������� ������������ ���� -> ����������� ��� �������� �� ��������� ����
            
            //��������� �����
            for (int i = 0; i < rows; i++)
            {
                int f1 = 0, f2 = 0, f3 = 0, f4 = 0, f5 = 0, f6 = 0, f7 = 0, f8 = 0, f9 = 0;
                for (int j = 0; j < cols; j++)
                {
                    if (grid[i, j] != -1)
                    {
                        switch (grid[i, j])
                        {
                            case 1: f1++; allCells++; break;
                            case 2: f2++; allCells++; break;
                            case 3: f3++; allCells++; break;
                            case 4: f4++; allCells++; break;
                            case 5: f5++; allCells++; break;
                            case 6: f6++; allCells++; break;
                            case 7: f7++; allCells++; break;
                            case 8: f8++; allCells++; break;
                            case 9: f9++; allCells++; break;
                        }
                    }
                }

                //��������� �����-��������
                if (f1 > 1)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if (grid[i, j] == 1 && zeroGrid[i, j])
                        {
                            if(prov == 0)
                                allCells = ColoringFore(i, j, allCells);
                            else
                                allCells = ColoringFore(j, i, allCells);
                        }
                    }
                }
                if (f2 > 1)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if (grid[i, j] == 2 && zeroGrid[i, j])
                        {
                            if (prov == 0)
                                allCells = ColoringFore(i, j, allCells);
                            else
                                allCells = ColoringFore(j, i, allCells);
                        }
                    }
                }
                if (f3 > 1)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if (grid[i, j] == 3 && zeroGrid[i, j])
                        {
                            if (prov == 0)
                                allCells = ColoringFore(i, j, allCells);
                            else
                                allCells = ColoringFore(j, i, allCells);
                        }
                    }
                }
                if (f4 > 1)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if (grid[i, j] == 4 && zeroGrid[i, j])
                        {
                            if (prov == 0)
                                allCells = ColoringFore(i, j, allCells);
                            else
                                allCells = ColoringFore(j, i, allCells);
                        }
                    }
                }
                if (f5 > 1)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if (grid[i, j] == 5 && zeroGrid[i, j])
                        {
                            if (prov == 0)
                                allCells = ColoringFore(i, j, allCells);
                            else
                                allCells = ColoringFore(j, i, allCells);
                        }
                    }
                }
                if (f6 > 1)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if (grid[i, j] == 6 && zeroGrid[i, j])
                        {
                            if (prov == 0)
                                allCells = ColoringFore(i, j, allCells);
                            else
                                allCells = ColoringFore(j, i, allCells);
                        }
                    }
                }
                if (f7 > 1)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if (grid[i, j] == 7 && zeroGrid[i, j])
                        {
                            if (prov == 0)
                                allCells = ColoringFore(i, j, allCells);
                            else
                                allCells = ColoringFore(j, i, allCells);
                        }
                    }
                }
                if (f8 > 1)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if (grid[i, j] == 8 && zeroGrid[i, j])
                        {
                            if (prov == 0)
                                allCells = ColoringFore(i, j, allCells);
                            else
                                allCells = ColoringFore(j, i, allCells);
                        }
                    }
                }
                if (f9 > 1)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if (grid[i, j] == 9 && zeroGrid[i, j])
                        {
                            if (prov == 0)
                                allCells = ColoringFore(i, j, allCells);
                            else
                                allCells = ColoringFore(j, i, allCells);
                        }
                    }
                }
            }//����� ������������� �������� ����� �� ������������� �����
            return allCells; //���������� ���-�� ������
        }

        private int VeryfySquares()
        {
            int val = 0;
            for (int n = 0; n < 3; n++)
            {
                for (int m = 0; m < 3; m++)
                {
                    List<int> list = new List<int>(9); //������ ���� ���������� ������
                    List<int> itmp = new List<int>(9);
                    List<int> jtmp = new List<int>(9);
                    /* �������� �������� � �������� */
                    for (int i = 0 + n * 3; i < 3 + n * 3; i++) //�������� � ��������
                    {
                        for (int j = 0 + 3 * m; j < 3 + 3 * m; j++) 
                        {
                            val = grid[i, j];
                            if (val == -1)   // ���� val=-1 -> �� ���������� ������
                            {
                                continue;
                            }
                            if (list.Contains(val)) //���� � �������� ��� ���� ��� ��������
                            {
                                if (!zeroGrid[i, j]) //���� �� ���������
                                {
                                    int index = list.IndexOf(val);
                                    ColoringFore(itmp[index], jtmp[index], 0);
                                }  
                                else //�� �� ���������
                                    ColoringFore(i, j, 0); //? ������ ������ ��������� ���������. ���������� ��� ����� ��������. ������������ ��� ���������, �� ������ ���� ����� �� ���������
                                return 0; //�������� ������
                            }
                            else
                            {
                                list.Add(val); //�������� ��� -> ���������
                                itmp.Add(i); //���� �����
                                jtmp.Add(j);
                            }
                        }
                    }
                    /* ����� �������� */
                }
            }
            return 81; //��� ������ ������ ��������
        }
        private void CheckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int allCells = 0; //������� ��������� ������������ ���� -> ����������� ��� �������� �� ��������� ����
            int rows = dataGridView1.RowCount; //���-�� �����
            int cols = dataGridView1.ColumnCount; //���-�� ��������

            for (int i = 0; i < rows; i++)
            {
                int f1 = 0, f2 = 0, f3 = 0, f4 = 0, f5 = 0, f6 = 0, f7 = 0, f8 = 0, f9 = 0;
                for (int j = 0; j < cols; j++)
                {
                    if (Convert.ToString(dataGridView1.Rows[i].Cells[j].Value) != "")
                    {
                        grid[i, j] = Convert.ToInt32(dataGridView1.Rows[i].Cells[j].Value);
                        switch (grid[i, j])
                        {
                            case 1: f1++; allCells++; break;
                            case 2: f2++; allCells++; break;
                            case 3: f3++; allCells++; break;
                            case 4: f4++; allCells++; break;
                            case 5: f5++; allCells++; break;
                            case 6: f6++; allCells++; break;
                            case 7: f7++; allCells++; break;
                            case 8: f8++; allCells++; break;
                            case 9: f9++; allCells++; break;
                        }
                    }
                }

                
            }

            allCells += CheckingMap(0); //�������� �� ������
            Transponing(); //�������� ��������
            allCells += CheckingMap(1);
            Transponing(); //���������� ����� �� �����                       
            allCells += VeryfySquares(); //�������� �� ��������

            if(allCells == 81*3)
            {
                label1.Visible = true;
            }            
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //������
        }

        private void Pon_Click(object sender, EventArgs e)
        {
            //�������� ����� �������
            pon.Visible = false;            
            int rows = dataGridView1.RowCount;
            int cols = dataGridView1.ColumnCount;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (grid[i, j] != -1 && zeroGrid[i, j]) //���� ������ �� ������
                    {
                        dataGridView1.Rows[i].Cells[j].Style.ForeColor = Color.Black; //������� ����� �� ���������
                    }
                    else continue; //�������� �����
                }
            }
        }
    }
}
