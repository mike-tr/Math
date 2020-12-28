using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MatrixMath {
    public class Matrix : MonoBehaviour {

        private double[, ] matrix;
        private (int, int) _shape = (0, 0);
        public (int, int) shape {
            get => _shape;
        }

        public int rows {
            get => _shape.Item1;
        }

        public int columns {
            get => _shape.Item2;
        }

        public double this [int j, int i] {
            get => matrix[j, i];
            set => matrix[j, i] = value;
        }

        public void addRowToRow (int target, int row, double scale = 1) {
            for (int i = 0; i < this.columns; i++) {
                matrix[target, i] += matrix[row, i] * scale;
            }
        }

        public void addToRow (int row, double value) {
            for (int i = 0; i < this.columns; i++) {
                matrix[row, i] += value;
            }
        }

        public void multiplyRow (int row, double value) {
            for (int i = 0; i < this.columns; i++) {
                matrix[row, i] *= value;
            }
        }

        public void devideRow (int row, double value) {
            for (int i = 0; i < this.columns; i++) {
                matrix[row, i] /= value;
            }
        }

        public override string ToString () {
            string me = "[";
            for (int i = 0; i < rows; i++) {
                me += i > 0 ? "\n [" : " [";
                for (int j = 0; j < columns; j++) {
                    me += j > 0 ? ", " + matrix[i, j].ToString ("0.##") : matrix[i, j].ToString ("0.##");
                }
                me += "]";
            }
            return me += "]";
        }

        public static double[] SolveMatrix (double[, ] matrix) {
            return SolveMatrix (new Matrix (matrix));
        }

        public static double[] SolveMatrix (float[, ] matrix) {
            return SolveMatrix (new Matrix (matrix));
        }
        public static double[] SolveMatrix (int[, ] matrix) {
            return SolveMatrix (new Matrix (matrix));
        }

        public double[] SolveMatrix () {
            return SolveMatrix (new Matrix (this));
        }

        public static double[] SolveMatrix (Matrix matrix) {
            // matrix
            // [  [1,-2, 1,-4],
            //    [0, 1, 2, 4],
            //    [2, 3,-2, 2]]

            var dead = new List<int> ();
            for (int j = 0; j < matrix.columns; j++) {
                Debug.Log ("Column : " + j);
                int v = -1;
                for (int i = 0; i < matrix.rows; i++) {
                    if (matrix[i, j] != 0) {
                        if (v == -1 && !dead.Contains (i)) {
                            v = i;
                            dead.Add (i);
                        }
                        matrix.devideRow (i, matrix[i, j]);
                    }
                }

                Debug.Log (matrix);
                if (v != -1) {
                    for (int i = 0; i < matrix.rows; i++) {
                        if (matrix[i, j] != 0) {
                            if (v == i) {
                                continue;
                            }
                            matrix.addRowToRow (i, v, -1);
                        }
                    }
                    Debug.Log (matrix);
                }
            }

            return null;
        }

        public Matrix (int[, ] matrix) {
            if (matrix.Length == 0) {
                this.matrix = new double[0, 0];
                return;
            }
            this._shape = (matrix.GetLength (0), matrix.GetLength (1));
            this.matrix = new double[rows, columns];

            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < columns; j++) {
                    this.matrix[i, j] = matrix[i, j];
                }
            }
        }
        public Matrix (float[, ] matrix) {
            if (matrix.Length == 0) {
                this.matrix = new double[0, 0];
                return;
            }
            this._shape = (matrix.GetLength (0), matrix.GetLength (1));
            this.matrix = new double[rows, columns];

            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < columns; j++) {
                    this.matrix[i, j] = matrix[i, j];
                }
            }
        }
        public Matrix (double[, ] matrix) {
            if (matrix.Length == 0) {
                this.matrix = new double[0, 0];
                return;
            }
            this._shape = (matrix.GetLength (0), matrix.GetLength (1));
            this.matrix = new double[rows, columns];

            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < columns; j++) {
                    this.matrix[i, j] = matrix[i, j];
                }
            }
        }

        public Matrix (Matrix matrix) {
            if (matrix.rows == 0) {
                this.matrix = new double[0, 0];
                return;
            }
            this._shape = (matrix.rows, matrix.columns);
            this.matrix = new double[rows, columns];

            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < columns; j++) {
                    this.matrix[i, j] = matrix[i, j];
                }
            }
        }
    }
}
