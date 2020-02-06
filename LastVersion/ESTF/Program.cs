using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Ideal
{
    static class Program
    {

        public static LoadingScreen splashForm;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var splashThread = new Thread(new ThreadStart(
             delegate
             {
                 splashForm = new LoadingScreen(); 
                 Application.Run(splashForm);
             } 
             ));

            splashThread.SetApartmentState(ApartmentState.STA);
            splashThread.Start();

            //run form - time taking operation
            var mainForm = new WorkSpace();
            //Est est = new Est();
            mainForm.Load += mainForm_Load;
           // est.Load += new EventHandler(mainForm_Load);
            Application.Run(mainForm);
          

        }

        static void mainForm_Load(object sender, EventArgs e)
        {
            //close splash
            if (splashForm == null)
            {
                return;
            }

            splashForm.Invoke(new Action(splashForm.Close));
            splashForm.Dispose();
            splashForm = null;

            // first tutor
            /*var configurationManager = new ConfigurationManager("TutorConfig.xml", new [] { "name", "email" });
            ProjectWindow.currentTutorName = configurationManager.getNode("name");
            ProjectWindow.currentTutorEmail = configurationManager.getNode("email");
            while (ProjectWindow.currentTutorName.Length == 0 || ProjectWindow.currentTutorEmail.Length == 0)
            {
                ProjectWindow.currentTutorName = Microsoft.VisualBasic.Interaction.InputBox(null, "Please enter tutor's name");
                configurationManager.setNode("name", ProjectWindow.currentTutorName);
                var email = Microsoft.VisualBasic.Interaction.InputBox(null, "Please enter tutor's email");
                if (ProjectWindow.isEmailVaild(email))
                {
                    ProjectWindow.currentTutorEmail = email;
                    configurationManager.setNode("email", ProjectWindow.currentTutorEmail);
                }

                configurationManager.save();
            }*/

            var configurationManager = new ConfigurationManager("TutorConfig.xml", new[] { "name", "email" });
            ProjectWindow.currentTutorName = configurationManager.getNode("name");
            ProjectWindow.currentTutorEmail = configurationManager.getNode("email");
            while ((ProjectWindow.currentTutorEmail.Length == 0 || ProjectWindow.currentTutorName.Length == 0) && !ProjectWindow.abortConfig )
            {
                var loginForm = new TutorLoginForm();
                loginForm.ShowDialog();
                configurationManager.setNode("name", ProjectWindow.currentTutorName);
                configurationManager.setNode("email", ProjectWindow.currentTutorEmail);
                configurationManager.save();
            }

            if(ProjectWindow.abortConfig)
                Application.Exit();

            /*ProjectWindow.currentTutorEmail = configurationManager.getNode("email");
            while (ProjectWindow.currentTutorEmail.Length == 0)
            {
                var email = Microsoft.VisualBasic.Interaction.InputBox(null, "Please enter tutor's email");
                if (ProjectWindow.isEmailVaild(email)) {
                    ProjectWindow.currentTutorEmail = email;
                    configurationManager.setNode("email", ProjectWindow.currentTutorEmail);
                    configurationManager.save();
                }
            }*/
            // new user
            configurationManager = new ConfigurationManager("LoginCofig.xml",new[]{ "name","email"});
            ProjectWindow.currentUserName = configurationManager.getNode("name");
            ProjectWindow.currentUserEmail = configurationManager.getNode("email");
            while ((ProjectWindow.currentUserEmail.Length == 0 || ProjectWindow.currentUserName.Length == 0) && !ProjectWindow.abortConfig)
            {
                var loginForm = new LoginForm();
                loginForm.ShowDialog();
                configurationManager.setNode("name", ProjectWindow.currentUserName);
                configurationManager.setNode("email", ProjectWindow.currentUserEmail);
                configurationManager.save();
            }

            if (ProjectWindow.abortConfig)
                Application.Exit();

            // generate the duck
            GenerateTheDuck();
            GenerateTheFeedback();
        }

        private static void GenerateTheDuck()
        {
            ProjectWindow.duckNodes = new[] { "d0", "d1", "d2", "d3" };
            ConfigurationManager configurationManager = new ConfigurationManager("DuckConfig.xml", ProjectWindow.duckNodes);
            //            configurationManager.setNode("d0", @"So what does your program need to do?
            //Give me some details.");
            //configurationManager.setNode("d1", @"And how does your code look like?
            //What is it supposed to do?");
            //          configurationManager.setNode("d2", @"Which bit doesn't work ?
            //What have you already tried to fix it?");
            //configurationManager.save();
            for (var i = 0; i < ProjectWindow.duckNodes.Length; i++)
            {
                ProjectWindow.duckNodes[i] = configurationManager.getNode(ProjectWindow.duckNodes[i]);
            }
        }
        private static void GenerateTheFeedback()
        {
            ProjectWindow.feedbackNodes = new Dictionary<string, string>
            {
                {"AbstractClassWithoutAbstractMethod", null},
                {"AccessorClassGeneration", null},
                {"AccessorMethodGeneration", null},
                {"ArrayIsStoredDirectly", null},
                {"AvoidPrintStackTrace", null},
                {"AvoidReassigningLoopVariables", null},
                {"AvoidReassigningParameters", null},
                {"AvoidStringBufferField", null},
                {"AvoidUsingHardCodedIP", null},
                {"CheckResultSet", null},
                {"ConstantsInInterface", null},
                {"DefaultLabelNotLastInSwitchStmt", null},
                {"ForLoopCanBeForeach", null},
                {"ForLoopVariableCount", null},
                {"GuardLogStatement", null},
                {"JUnitSuitesShouldUseSuiteAnnotation", null},
                {"JUnitTestShouldUseAfterAnnotation", null},
                {"JUnitTestShouldUseBeforeAnnotation", null},
                {"JUnitTestShouldUseTestAnnotation", null},
                {"JUnitAssertionsShouldIncludeMessage", null},
                {"JUnitTestContainsTooManyAsserts", null},
                {"JUnitTestsShouldIncludeAssert", null},
                {"JUnitUseExpected", null},
                {"LooseCoupling", null},
                {"MethodReturnsInternalArray", null},
                {"MissingOverride", null},
                {"OneDeclarationPer", null},
                {"PositionLiteralsFirstInCaseInsensitiveComparisons", null},
                {"PositionLiteralsFirstInComparisons", null},
                {"PreserveStackTrace", null},
                {"ReplaceEnumerationWithIterator", null},
                {"ReplaceHashtableWithMap", null},
                {"ReplaceVectorWithList", null},
                {"SwitchStmtsShouldHaveDefault", null},
                {"SystemPrintln", null},
                {"UnusedFormalParameter", null},
                {"UnusedImports", null},
                {"UnusedLocalVariable", null},
                {"UnusedPrivateField", null},
                {"UnusedPrivateMethod", null},
                {"UseAssertEqualsInsteadOfAssertTrue", null},
                {"UseAssertNullInsteadOfAssertTrue", null},
                {"UseAssertSameInsteadOfAssertTrue", null},
                {"UseAssertTrueInsteadOfAssertEquals", null},
                {"UseCollectionIsEmpty", null},
                {"UseTryWithResources", null},
                {"UseVarargs", null},
                {"WhileLoopWithLiteralBoolean", null}
            };
           

            ConfigurationManager configurationManager = new ConfigurationManager("FeedbackConfig.xml", ProjectWindow.feedbackNodes.Keys.ToArray());

            var list = new List<string>();
            foreach(var key in ProjectWindow.feedbackNodes.Keys)
            {
                list.Add(key);
            }
            foreach(var key in list)
            {
                ProjectWindow.feedbackNodes[key] = configurationManager.getNode(key);
            }
        }
    }
}
