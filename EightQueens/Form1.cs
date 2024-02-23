using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EightQueens
{
    public partial class Form1 : Form
    {
        public int[, ] board = new int[8, 8];
        public Form1()
        {
            InitializeComponent();
        }
        public bool isSafe(int row, int col)
        {
            for (int x = 0; x < col; x++)
                if (board[row, x] == 1)
                    return false;
            for (int x = row, y = col; x >= 0 && y >= 0;
                 x--, y--)
                if (board[x, y] == 1)
                    return false;
            for (int x = row, y = col; x < board.GetLength(0) && y >= 0;
                 x++, y--)
                if (board[x, y] == 1)
                    return false;
            return true;
        }
        public bool PlaceQueens(int col) {
            if (col == board.GetLength(0))
            {
                return true;
            }
            for (int i = 0; i < board.GetLength(0); i++)
            {
                if(isSafe(i, col))
                {
                    board[i, col] = 1;
                    if (PlaceQueens(col + 1))
                        return true;
                    board[i, col] = 0;
                }
                
            }
            return false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            board = new int[8, 8];
            int h = board.GetLength(0);
            int w = board.GetLength(1);
            int cellSize = 50;
            this.dataGridView1.ColumnCount = w;
            this.dataGridView1.RowCount = h;
            this.dataGridView1.Width = cellSize * 8 + 3;
            this.dataGridView1.Height = cellSize * 8 + 3;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.Width = cellSize;
            }
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Height = cellSize;
            }
            PlaceQueens(0);

            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    dataGridView1[i, j].Value = board[j,i];

                    if (i % 2 !=0)
                        if(j % 2 == 0)
                            dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Green;
                    if (i % 2 == 0)
                        if (j % 2 != 0)
                            dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Green;

                    if (board[i, j] != 0)
                    {
                        dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Red;

                    }
                }
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int x = e.RowIndex;
            int y = e.ColumnIndex;
            if (board[x, y] != 0)
            {
                dataGridView1.Rows[x].Cells[y].Style.BackColor = Color.Blue;
                for(int i = 0; i < board.GetLength(0); i++)
                {
                    for(int j = 0;j < board.GetLength(1); j++)
                    {
                        if(i == e.RowIndex)
                        {   
                            dataGridView1.Rows[e.RowIndex].Cells[j].Style.BackColor = Color.Blue;     
                        }
                        if(j == e.ColumnIndex)
                        {
                            dataGridView1.Rows[i].Cells[e.ColumnIndex].Style.BackColor = Color.Blue;
                        }
                        if(i - e.RowIndex + 1 == j - e.ColumnIndex + 1)
                        {
                            dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Blue;
                        }
                        if(i + j == e.RowIndex + e.ColumnIndex)
                        {
                            dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Blue;
                        }
                    }
                }
            }
        }
    }
}
