using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_Sharp
{
    class Matrix
    {
        private int rows;
        private int cols;
        private double[,] array;

        public Matrix()
        {
            rows = 3;
            cols = 3;
            array = new double[rows,cols];
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    array[i, j] = 0;
                }
        }

        public Matrix(int r, int c)
        {
            rows = r;
            cols = c;
            array = new double[rows, cols];
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                {
                    array[i, j] = 0;
                }
        }

        public Matrix(int num)
        {
            rows = num;
            cols = num;
            array = new double[num, num];
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                {
                    array[i, j] = 0;
                }
        }

        public void input()
        {
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                {
                    Console.Write("arr[" + i + ',' + j + "]=");
                    array[i, j] = Double.Parse(Console.ReadLine());
                }
        }
        public void info()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(array[i,j]+" ");
                }
                Console.WriteLine();
            }
        }
        public static Matrix operator + (Matrix par1, double val)
        {
            Matrix s= new Matrix(par1.rows,par1.cols);
            for (int i = 0; i < s.rows; i++)
            {
                for (int j = 0; j < s.cols; j++)
                {
                    s.array[i, j] = par1.array[i,j];
                }
            }
            for (int i = 0; i < s.rows; i++)
            {
                for (int j = 0; j <s.cols; j++)
                {
                    s.array[i,j]+= val;
                }
            }
            return s;
        }

        public static Matrix operator +(Matrix par1,Matrix par2)
        {
            Matrix s = new Matrix(par1.rows, par1.cols);
            for (int i = 0; i < s.rows; i++)
            {
                for (int j = 0; j < s.cols; j++)
                {
                    s.array[i, j] = par1.array[i, j];
                }
            }
            for (int i = 0; i < par1.rows; i++)
            {
                for (int j = 0; j < par1.cols; j++)
                {
                    s.array[i, j] = par1.array[i, j] + par2.array[i,j];
                }
            }
            return s;
        }
        public static Matrix operator -(Matrix par1, double val)
        {
            Matrix s = new Matrix(par1.rows, par1.cols);
            for (int i = 0; i < s.rows; i++)
            {
                for (int j = 0; j < s.cols; j++)
                {
                    s.array[i, j] = par1.array[i, j];
                }
            }
            for (int i = 0; i < s.rows; i++)
            {
                for (int j = 0; j < s.cols; j++)
                {
                    s.array[i, j] -= val;
                }
            }
            return s;
        }

        public static Matrix operator -(Matrix par1, Matrix par2)
        {
            Matrix s = new Matrix(par1.rows, par1.cols);
            for (int i = 0; i < s.rows; i++)
            {
                for (int j = 0; j < s.cols; j++)
                {
                    s.array[i, j] = par1.array[i, j];
                }
            }
            for (int i = 0; i < par1.rows; i++)
            {
                for (int j = 0; j < par1.cols; j++)
                {
                    s.array[i, j] = par1.array[i, j] - par2.array[i, j];
                }
            }
            return s;
        }

        public static bool operator <(Matrix m1, Matrix m2)
        {
            bool f=true;
            if (m2.rows == m1.rows && m2.cols == m1.cols)
            {
                for (int i = 0; i <m1.rows; i++)
                {
                    for (int j = 0; j < m1.cols; j++)
                    {
                        if (!(m1.array[i, j] < m2.array[i, j])) f = false;
                    }
                }
            }
            else f = false;
            return f;
        }

        public static bool operator >(Matrix m1, Matrix m2)
        {
            bool f = true;
            if (m2.rows == m1.rows && m2.cols == m1.cols)
            {
                for (int i = 0; i < m1.rows; i++)
                {
                    for (int j = 0; j < m1.cols; j++)
                    {
                        if (!(m1.array[i, j] > m2.array[i, j])) f = false;
                    }
                }
            }
            else f = false;
            return f;
        }

        public Matrix trans()
        {

            Matrix m= new Matrix(this.cols,this.rows);
            for (int i = 0, k = 0; (i < this.rows && k < m.cols); i++,k++)
            {
                for (int j = 0, o = 0; (j < this.cols && o < m.rows); j++, o++)
                {
                    m.array[j, i] = this.array[i, j];
                }
            }
            return m;
        }
        public double this [int i, int j]{
			get{
				return array[i,j];
			   }
			set{
				array[i,j]=value;
			}
			}
        public int Rows{
			get{return rows;}
			set{this.rows=value; }
		}
        public Matrix GAUSS(Matrix X){
        	int n=this.rows;
        	double max,z;
        	int r;
        	for (int k = 0; k < n-1; k++) {
        		max=Math.Abs(this.array[k,k]);
        		r=k;
        		for (int i = k+1; i < n-1; i++) {
        			z=Math.Abs(this.array[i,k]);//A[i,k]);
        			if(z>max) max=Math.Abs(this.array[i,k]);//A[i,k]);
        		}
        		for (int i = k+1; i < n-1; i++) {
        			z=Math.Abs(this.array[i,k]);//A[i,k]);
        			if(z>max) r=i;
        		}
        		for (int j = 0; j < n+1; j++) {
        			double c;
        			c=(double) this.array[k,j];//A.array[k,j];
        			this.array[k,j]=this.array[r,j];//A.array[k,j]=(double) A.array[r,j];
        			this.array[r,j]=(double) c;//A.array[r,j]=(double)c;
        		}
        		for (int s = n+1; s < k; s--) {
        			this.array[k,s]=this.array[k,s]/this.array[k,k];//A[k,s]=A[k,s]/A[k,k];
        		}
        		for (int i = k+1; i < n; i++) {
        			double M=this.array[i,k]/this.array[k,k];//A[i,k]/A[k,k];
        			for (int j = k; j < n+1; j++) {
        				this.array[i,j]=this.array[i,j]-M*this.array[k,j];//A[i,j]=A[i,j]-M*A[k,j];
        			}
        		}
        	}
        	double r1;
        	r1=this.array[n,n];//r1=A[n,n];
        	for (int s = n; s < n+1; s++) {
        		this.array[n,s]=this.array[n,s]/r1;//A[n,s]=A[n,s]/r1;
        	}
        	//Matrix X = new Matrix(n,1);
        	X.array[n,1]=this.array[n,n+1];//X[n,1]=A[n,n+1];
        	double sum=0;
        	for (int i = n-1; i < 0; i++) {
        		for (int j = i+1; j < n; j++) {
        			sum+=this.array[i,j]*X.array[j,1];
        			Console.WriteLine("j loop sum="+sum);//sum+=A[i,j]*X[j,1];
        		}
        		X.array[i,1]=this.array[i,n+1]-sum;//X[i,1]=A[i,n+1]-sum;
        	}
        	return X;	
        }

    }
}
