using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryDuplicateFiles
{
    class QueryByFileName
    {
        public string Name { get; set; }
        public override bool Equals(object obj)
        {
            QueryByFileName other = (QueryByFileName)obj;
            return other.Name == this.Name;
        }
        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }
        public override string ToString()
        {
            return this.Name;
        }
    }
    class QueryByFileNameAndLength
    {
        public string Name { get; set; }
        public long Length { get; set; }
        public override bool Equals(object obj)
        {
            QueryByFileNameAndLength other = (QueryByFileNameAndLength)obj;
            return other.Length == this.Length &&
                   other.Name == this.Name;
        }
        public override int GetHashCode()
        {
            string str = String.Format("{0}{1}", this.Length, this.Name);
            return str.GetHashCode();
        }
        public override string ToString()
        {
            return String.Format("{0} {1}", this.Name, this.Length);
        }
    }
    class QueryByFileNameAnddLengthAndCreationDate
    {
        public string Name { get; set; }
        public DateTime CreationTime { get; set; }
        public long Length { get; set; }
        public override bool Equals(object obj)
        {
            QueryByFileNameAnddLengthAndCreationDate other = (QueryByFileNameAnddLengthAndCreationDate)obj;
            return other.Length == this.Length &&
                   other.Name == this.Name&&
                   other.CreationTime== this.CreationTime;
        }
        public override int GetHashCode()
        {
            string str = String.Format("{0}{1}{2}", this.CreationTime, this.Length, this.Name);
            return str.GetHashCode();
        }
        public override string ToString()
        {
            return String.Format("{0} {1} {2}", this.Name, this.Length, this.CreationTime);
        }
    }
}
