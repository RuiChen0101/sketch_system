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
            DrawingTestTool.MouseClick(150, 150);
            Robot.AssertText("_info", "Selected : Line(100,100,200,200)");

            Robot.ClickButton("_rectangle");
            DrawingTestTool.MouseDraw(201, 100, 300, 200);
            DrawingTestTool.MouseClick(250, 150);
            Robot.AssertText("_info", "Selected : Rectangle(201,100,300,200)");

            Robot.ClickButton("_hexagon");
            DrawingTestTool.MouseDraw(301, 100, 400, 200);
            DrawingTestTool.MouseClick(350, 150);
            Robot.AssertText("_info", "Selected : Hexagon(301,100,400,200)");

            Robot.ClickButton("_clear");
        }

        //CodedUIButtonTest
        [TestMethod]
        public void UIDrawTest()
        {
            Robot.ClickButton("_hexagon");
            DrawingTestTool.MouseDraw(631, 151, 806, 390);
            Robot.ClickButton("_rectangle");
            DrawingTestTool.MouseDraw(69, 65, 350, 211);
            DrawingTestTool.MouseDraw(733, 484, 705, 347);
            Robot.ClickButton("_line");
            DrawingTestTool.MouseDraw(318, 212, 700, 404);
            DrawingTestTool.MouseDraw(633, 522, 704, 482);
            DrawingTestTool.MouseDraw(800, 535, 736, 486);
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
