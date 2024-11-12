using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Anastasia_Erileeva_kt_42_21.Database;
using Anastasia_Erileeva_kt_42_21.Interfaces;
using Anastasia_Erileeva_kt_42_21.Models;
using Microsoft.EntityFrameworkCore;


namespace AnastasiaErileevaKt_42_21.Tests
{
    public class GroupTests
    {
        [Fact]
        public void IsValidGroupName_KT4221_True()
        {
            //arrange
            var testGroup = new Anastasia_Erileeva_kt_42_21.Models.Group
            {
                GroupName = "КТ-42-21"
            };

            //act
            var result = testGroup.IsValidGroupName();

            //assert
            Assert.True(result);
        }
    }
}
