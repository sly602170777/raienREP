namespace aspnetMVCProject.Models
{
    public class user
    {
        #region 定义属性
        public string Name { get; set; }
        public string Id { get; set; }
        //public int MyProperty { get; set; }

        #endregion

        public user ()
        {
        }
        public user (string id, string name)
        {

            Name = name;
            Id = id;
        }


    }
}