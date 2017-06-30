using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebMaze.Models
{
    public class UsersClassModel
    {
        private string userName;
        private string password;
        private int lose;
        private int win;

        public UsersClassModel()
        {
            userName = "newUser";
            password = "1234";
            lose = 0;
            win = 0;
        }

        [Key]
        public string UserName
        {
            get { return this.userName; }
            set { this.userName = value;}
        }

        public string Password
        {
            get { return this.password; }
            set { this.password = value; }
        }

        public int Win
        {
            get { return this.win; }
            set { this.win++; }
        }

        public int Lose
        {
            get { return this.lose; }
            set { this.lose++; }
        }
    }
}