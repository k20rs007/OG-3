using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class minigame_2Script : MonoBehaviour
{
    string ice1 = "";
    string ice2 = "";
    string ice3 = "";

    string ichigo = "�������A�C�X";
    string greentea = "�܂�����A�C�X";
    string chocolate = "�`���R���[�g�A�C�X";

    int ice1_Flavor = 0; // 0:�A�C�X����`
    int ice2_Flavor = 0; // 0:�A�C�X����`
    int ice3_Flavor = 0; // 0:�A�C�X����`

    public int roundCounter = 1;

    string order = "";

    int show = 1;

    int correct = 0;
    int wrong = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(show == 1)
        {
            int ice1_flavor_rnd = Random.Range(1, 4);
            if (ice1_flavor_rnd == 1)
            {
                ice1 = ichigo;
                ice1_Flavor = 1; // 1:�������A�C�X
            }
            else if (ice1_flavor_rnd == 2)
            {
                ice1 = greentea;
                ice1_Flavor = 2; // 2:�܂�����A�C�X
            }
            else
            {
                ice1 = chocolate;
                ice1_Flavor = 3; // 3:�`���R���[�g�A�C�X
            }

            if (roundCounter > 5)
            {
                int ice2_flavor_rnd = Random.Range(1, 4);
                if (ice2_flavor_rnd == 1)
                {
                    ice2 = ichigo;
                    ice2_Flavor = 1; // 1:�������A�C�X
                }
                else if (ice2_flavor_rnd == 2)
                {
                    ice2 = greentea;
                    ice2_Flavor = 2; // 2:�܂�����A�C�X
                }
                else
                {
                    ice3 = chocolate;
                    ice3_Flavor = 3; // 3:�`���R���[�g�A�C�X
                }
            }

            if (roundCounter > 10)
            {
                int ice3_flavor_rnd = Random.Range(1, 4);
                if (ice3_flavor_rnd == 1)
                {
                    ice3 = ichigo;
                    ice3_Flavor = 1; // 1:�������A�C�X
                }
                else if (ice3_flavor_rnd == 2)
                {
                    ice3 = greentea;
                    ice3_Flavor = 2; // 2:�܂�����A�C�X
                }
                else
                {
                    ice3 = chocolate;
                    ice3_Flavor = 3; // 3:�`���R���[�g�A�C�X
                }
            }

            order = ice1 + "\n" + ice2 + "\n" + ice3 + "\n" + roundCounter;

            gameObject.GetComponent<Text>().text = order;
            
            show = 0;
        }
    }

    public void counter()
    {
        roundCounter++;
        show = 1;
    }

    void ice1_button()
    {
        if(ice1_Flavor == 1)
        {
            correct++;
        }
    }

    void ice2_button()
    {

    }

    void ice3_button()
    {

    }
}
