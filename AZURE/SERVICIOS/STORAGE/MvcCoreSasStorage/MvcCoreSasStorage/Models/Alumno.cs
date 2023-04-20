﻿using Azure;
using Azure.Data.Tables;

namespace MvcCoreSasStorage.Models
{
    public class Alumno : ITableEntity
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int Nota { get; set; }

        private int _IdAlumno;
        public int IdAlumno
        {
            get { return this._IdAlumno; }
            set
            {
                this._IdAlumno = value;
                this.RowKey = value.ToString();
            }
        }

        private string _Curso;
        public string Curso
        {
            get { return this._Curso; }
            set
            {
                this._Curso = value;
                this.PartitionKey = value.ToString();
            }
        }

        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }
    }
}
