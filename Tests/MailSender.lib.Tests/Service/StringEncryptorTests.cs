using System;
using System.Text;
using System.Collections.Generic;
using MailSender.lib.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MailSender.lib.Tests.Service
{
    /// <summary>Класс модульных тестов для StringEncryptor</summary>
    [TestClass]
    public class StringEncryptorTests
    {
        public StringEncryptorTests()
        {
            //
            // TODO: добавьте здесь логику конструктора
            //
        }

        private TestContext _TestContextInstance;

        /// <summary>
        ///Получает или устанавливает контекст теста, в котором предоставляются
        ///сведения о текущем тестовом запуске и обеспечивается его функциональность.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return _TestContextInstance;
            }
            set
            {
                _TestContextInstance = value;
            }
        }

        #region Дополнительные атрибуты тестирования

        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext testContext)
        {

        }
        
        //
        // При написании тестов можно использовать следующие дополнительные атрибуты:
        //
        // ClassInitialize используется для выполнения кода до запуска первого теста в классе
        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {

        }
        //
        // ClassCleanup используется для выполнения кода после завершения работы всех тестов в классе
        [ClassCleanup]
        public static void MyClassCleanup()
        {

        }
        //
        // TestInitialize используется для выполнения кода перед запуском каждого теста 
        [TestInitialize]
        public void MyTestInitialize()
        {

        }
        //
        // TestCleanup используется для выполнения кода после завершения каждого теста
        [TestCleanup]
        public void MyTestCleanup()
        {

        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {

        }

        #endregion

        [TestMethod]
        public void EncryptMethod_On_ASD_Return_BTE_WithKey_1()
        {
           // AAA
           // Arrange
           const string str = "ASD";
           const string expected_result = "BTE";
           const int key = 1;

           // Act
           var actual_result = StringEncryptor.Encrypt(str, key);

           // Assert
           Assert.AreEqual(expected_result, actual_result, $"Ошибка {str} кодирования");
           //StringAssert.Matches();
           //CollectionAssert.

           if(expected_result != actual_result)
               throw new AssertFailedException("Ошибка в методе кодирования данных");
        }

        [TestMethod]
        public void DecriptMethod_On_BTE_Return_ASD_WithKey_1()
        {
            // AAA
            // Arrange
            const string str = "BTE";
            const string expected_result = "ASD";
            const int key = 1;

            // Act
            var actual_result = StringEncryptor.Decrypt(str, key);

            // Assert
            Assert.AreEqual(expected_result, actual_result);
        }
    }
}
