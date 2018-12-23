using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelaAleatorizador.Infra
{
    public class codigoBruto
    {
        public List<FileInfo> GetFile(string path)
        {
            DirectoryInfo di = new DirectoryInfo(path);
            List<FileInfo> arquivos = new List<FileInfo>();
            foreach (var item in di.GetFiles())
            {
                arquivos.Add(item);
            }
            return arquivos.OrderBy(f => f.Length).ToList();
        }

        public int ReturnQuantFiles(string path)
        {
            DirectoryInfo di = new DirectoryInfo(path);

            return di.GetFiles(path).Count();
        }

        public void RenameFiles(List<FileInfo> ListSorted, string path)
        {
            int i = 0;
            DirectoryInfo di = new DirectoryInfo(path);

            string caminho = di.FullName;

            foreach (var item in ListSorted)
            {
                i++;
                item.MoveTo(path + "Musica " + i + ".mp3");
            }
         
        }

    }
}
