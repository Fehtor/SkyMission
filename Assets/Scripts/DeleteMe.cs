using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteMe : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int i = 10000;
        int sum = 0;
        char digit = '3';

        while (i < 100000)
        {

            bool haveThree = false;
            string str_i = i.ToString();

            int j = 0;
            for (; j < str_i.Length; j++)
            {
                if (str_i[j] == digit)
                {
                    sum++;
                    haveThree = true;
                    break;
                }

                if (haveThree)
                {
                    switch (j)
                    {
                        case 0:
                            i += 10000;
                            sum += 9999;
                            break;

                        case 1:
                            i += 1000;
                            sum += 999;
                            break;

                        case 2:
                            i += 100;
                            sum += 99;
                            break;

                        case 3:
                            i += 10;
                            sum += 9;
                            break;
                    }
                }
                if (j > 3)
                {
                    i++;
                }
            }

        }
        print(sum);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
