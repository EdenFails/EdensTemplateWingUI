using MelonLoader;
using System;
using System.Collections;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;




namespace EdensTemplate
{
    class Main : MelonMod
    {



        public override void OnApplicationStart()
        {
            MelonCoroutines.Start(waitforui());
        }

        [MethodImpl(MethodImplOptions.NoOptimization)]
        private IEnumerator waitforui()
        {
            MelonLogger.Msg("Waiting For Ui");
            while (GameObject.Find("UserInterface") == null)
                yield return null;

            while (GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)") == null)
                yield return null;

            MelonLogger.Msg("Ui loaded");


            //----------------------------------------------------------------------------------------------------------------------------------------------------------This is the main button
            //

            var toinst = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Wing_Right/Container/InnerContainer/WingMenu/ScrollRect/Viewport/VerticalLayoutGroup/Button_Emotes");
            var insts = GameObject.Instantiate(toinst, toinst.parent).gameObject;
            insts.name = "Button Open Menu";
            var txts = insts.transform.Find("Container/Text_QM_H3").GetComponent<TMPro.TextMeshProUGUI>();
            txts.richText = true;
            txts.text = ($"<color=#0296CD>RENAME THIS Open Menu </color>");
            GameObject.DestroyImmediate(insts.transform.Find("Container/Icon").gameObject);
            var btns = insts.GetComponent<UnityEngine.UI.Button>();
            btns.onClick.RemoveAllListeners();
            btns.onClick.AddListener(new System.Action(() =>
            {

                ///Button that is appears after - You can change the variables that have 1 after then (toinst1, inst1, txt1 , btn1) if you want to add more buttons copy and past this chunk and 
                //just change the 1 to a 2 or something like that                  --- Can also change the Window/Wing_Left to be Window/Wing_Right if you want the additional buttons to be on the right instead of left
                var toinst1 = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Wing_Left/Container/InnerContainer/WingMenu/ScrollRect/Viewport/VerticalLayoutGroup/Button_Emotes");
                var inst1 = GameObject.Instantiate(toinst1, toinst1.parent).gameObject;
                inst1.name = "Button";
                var txt1 = inst1.transform.Find("Container/Text_QM_H3").GetComponent<TMPro.TextMeshProUGUI>();
                txt1.richText = true;
                txt1.text = ($"<color=#4CB750>Example Button</color>") ;
                GameObject.DestroyImmediate(inst1.transform.Find("Container/Icon").gameObject);
                var btn1 = inst1.GetComponent<UnityEngine.UI.Button>();
                btn1.onClick.RemoveAllListeners();
                btn1.onClick.AddListener(new System.Action(() =>
                {
                    MelonCoroutines.Start(loadui());
                    
                }));
               




                    
                // This one is to make it close the menue
                    var toinstclose = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Wing_Right/Container/InnerContainer/WingMenu/ScrollRect/Viewport/VerticalLayoutGroup/Button_Emotes");
                 var instsclose = GameObject.Instantiate(toinstclose, toinstclose.parent).gameObject;
                    instsclose.name = "Button Close Menu";
                    var txtsclose = instsclose.transform.Find("Container/Text_QM_H3").GetComponent<TMPro.TextMeshProUGUI>();
                 txtsclose.richText = true;
                 txtsclose.text = ($"<color=#0296CD>Close Menu</color>");
                 GameObject.DestroyImmediate(instsclose.transform.Find("Container/Icon").gameObject);
                  var btnsclose = instsclose.GetComponent<UnityEngine.UI.Button>();
                  btnsclose.onClick.RemoveAllListeners();
                  btnsclose.onClick.AddListener(new System.Action(() =>
                {

                    // If you add any buttons make sure to add them to this so it removes them when you close the menu
                GameObject.DestroyObject(toinst1);
                GameObject.DestroyObject(inst1);
                GameObject.DestroyObject(txt1);
                GameObject.DestroyObject(btn1);//

                GameObject.DestroyObject(toinst);
                GameObject.DestroyObject(insts);
                GameObject.DestroyObject(txts);
                GameObject.DestroyObject(btns);//

                GameObject.DestroyObject(btnsclose);
                GameObject.DestroyObject(instsclose);
                GameObject.DestroyObject(txtsclose);
                GameObject.DestroyObject(btnsclose);//


            }));
            }));


        }


        private IEnumerator loadui()
        {
            //Put the code you want it to execute here


            throw new NotImplementedException();
        }


    }
}