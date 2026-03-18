using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scanner
{
    internal class SourceCode
    {
        public string sourceCode { get; set; } = @"
                int main() {
                int x, y;
                // This is a single-line comment
                if (x == 42) {
                    /* This is
                       a block
                       comment */
                    x = x - 3;
                } else {
                    y = 3.1; // Another comment
                }
                return 0;
                }";
    }
}
