using EmployeeApplication.Infrastructure.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApplication.Core.Service.Helper
{
    public class FileUploadHelper: IFileUploadHelper
    {
        private readonly EmployeeApplicationContext _context;
        public FileUploadHelper(EmployeeApplicationContext context)
        {
            _context = context;
        }
        public async Task<string> UploadEmployee(IFormFile file)
        {
            try
            {
                  var filename = file.FileName.Substring(0, file.FileName.LastIndexOf('.'));
                var ext = file.FileName.Substring(file.FileName.LastIndexOf('.'), file.FileName.Length - file.FileName.LastIndexOf('.'));
                filename += Guid.NewGuid().ToString();
                var filepath = $"wwwroot/images/{filename + ext}";
                using (var fstream = System.IO.File.Create(filepath))
                {
                    var stream = file.OpenReadStream();
                    fstream.Seek(0, SeekOrigin.Begin);
                    stream.CopyTo(fstream);
                }
                return filepath;

            }catch(Exception ex)
            {
                throw;
            }
        }
    }
}
