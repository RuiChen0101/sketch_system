using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;


namespace DrawingUITest
{
    /// <summary>
    /// CodedUITest1 的摘要說明
    /// </summary>
    [CodedUITest]
    public class UITest
    {
        private const string FILE_PATH = "..\\..\\..\\DrawingForm\\bin\\Debug\\DrawingForm.exe";
        private const string APP_TITLE = "MainWindow";

        //init
        [TestInitialize()]
        public void Initialize()
        {
            Robot.Initialize(FILE_PATH, APP_TITLE);
        }


        //CodedUIButtonTest
        [TestMethod]
        public void UIButtonTest()
        {
            Robot.ClickButton("_line");
            DrawingTestTool.MouseDraw(100, 100, 200, 200);

            Robot.ClickButton("_rectangle");
            DrawingTestTool.MouseDraw(100, 100, 200, 200);

            Robot.ClickButton("_clear");
        }

        //CodedUIButtonTest
        [TestMethod]
        public void UIDrawTest()
        {
            Robot.ClickButton("_line");
            DrawingTestTool.MouseDraw(400, 100, 600, 300);
            DrawingTestTool.MouseDraw(400, 100, 200, 300);
            Robot.ClickButton("_rectangle");
            DrawingTestTool.MouseDraw(200, 300, 600, 500);
            DrawingTestTool.MouseDraw(600, 200, 650, 350);
            DrawingTestTool.MouseDraw(250, 325, 350, 375);
            DrawingTestTool.MouseDraw(400, 325, 500, 375);
            DrawingTestTool.MouseDraw(350, 400, 450, 500);
            Robot.ClickButton("_clear");
        }

        //Cleanup
        [TestCleanup()]
        public void Cleanup()
        {
            Robot.CleanUp();
        }
    }
}
