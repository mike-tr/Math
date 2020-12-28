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

        public static void SolveMatrix (double[][] matrix) {
            SolveMatrix (new Matrix (matrix));
        }

        public static void SolveMatrix (float[][] matrix) {
            SolveMatrix (new Matrix (matrix));
        }
        public static void SolveMatrix (int[][] matrix) {
            SolveMatrix (new Matrix (matrix));
        }

        public static void SolveMatrix (Matrix matrix) {
            // matrix
            // [  [1,-2, 1,-4],
            //    [0, 1, 2, 4],
            //    [2, 3,-2, 2]]

        }

        public Matrix (int[][] matrix) {
            if (matrix.Length == 0) {
                this.matrix = new double[0, 0];
                return;
            }
            this.matrix = new double[matrix.Length, matrix[0].Length];
            for (int i = 0; i < matrix.Length; i++) {
                for (int j = 0; j < matrix[0].Length; j++) {
                    this.matrix[i, j] = matrix[i][j];
                }
            }
        }
        public Matrix (float[][] matrix) {
            if (matrix.Length == 0) {
                this.matrix = new double[0, 0];
                return;
            }
            this.matrix = new double[matrix.Length, matrix[0].Length];
            for (int i = 0; i < matrix.Length; i++) {
                for (int j = 0; j < matrix[0].Length; j++) {
                    this.matrix[i, j] = matrix[i][j];
                }
            }
        }
        public Matrix (double[][] matrix) {
            if (matrix.Length == 0) {
                this.matrix = new double[0, 0];
                return;
            }
            this._shape = (matrix.Length, matrix[0].Length);
            this.matrix = new double[shape.Item1, shape.Item2];

            for (int i = 0; i < shape.Item1; i++) {
                for (int j = 0; j < shape.Item1; j++) {
                    this.matrix[i, j] = matrix[i][j];
                }
            }
        }
    }
}
