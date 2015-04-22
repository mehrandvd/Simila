module levenstein {
    export class levensteinAlgorithm {
        getDistance(left: string, right: string): number {
            var n = left.length;
            var m = right.length;
            var d: number[][] = new Array<number[]>(2);// = [2, m + 1];

            var newrow = 1;
            var oldrow = 0;
            var temp = 0;

            if (n == 0) {
                return m;
            }

            if (m == 0) {
                return n;
            }

            //filling the first row and cloumns of the matrix
            for (var i = 0; i < 2; i++) {
                d[i] = new Array<number>(m + 1);
                d[i][0] = i - 1;
            }

            for (var j = 0; j <= m; j++) {
                d[0][j] = j - 1;
            }

            // comparing
            for (i = 1; i <= n; i++)
            {
                for (j = 1; j <= m; j++) {
                    var updateCost = right[j - 1] === left[i - 1] ? 0 : 1;//this.CostResolver.GetUpdateCost(right[j - 1], left[i - 1]);
                    var deleteCost = 1; //this.CostResolver.GetInsertOrDeleteCost(left[i - 1]);
                    d[newrow][j] = Math.min(
                        Math.min(d[oldrow][j] + 1, d[newrow][j - 1] + deleteCost),
                        d[oldrow][j - 1] + updateCost);

                }

                temp = newrow;
                newrow = oldrow;
                oldrow = temp;

                d[newrow][0] = i + 1;

            }

            return d[temp][m];    
        }
    }
}