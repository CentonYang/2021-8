using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NPCR : MonoBehaviour
{
    private GameObject ���a;
    private Vector3 ��l�y��;
    private Animator �e�{�C��;
    public float �l���b�|;
    public float �C���b�|;
    public float ĵ�٥b�|;
    public float �۽åb�|;
    public float �����d��;
    public float ���ʳt��;
    public float �ਭ�t��;
    private enum NPC���A
    { �[��, ����, ĵ��, �l��, ��^ }
    private NPC���A �ثe���A = NPC���A.�[��;
    private float �¯ٶZ��;
    private float ��^�Z��;
    private Quaternion �ਭ���;
    public float[] �ܦ��v�� = { 100, 200 };
    public float ���y���;
    float ���O�ɶ�;
    bool ����;
    bool �]�B;
    public static bool �Ȱ�;
    public GameObject �Q��;

    void Start()
    {
        �Ȱ� = false;
        ���a = GameObject.FindGameObjectWithTag("Player");
        �e�{�C�� = GetComponent<Animator>();
        ��l�y�� = gameObject.GetComponent<Transform>().position;
        �C���b�| = Mathf.Min(�C���b�|, �l���b�|);
        �۽åb�| = Mathf.Min(�۽åb�|, ĵ�٥b�|);
        �����d�� = Mathf.Min(�����d��, �۽åb�|);
        �H�����A();
    }
    void �H�����A()
    {
        ���O�ɶ� = Time.time;
        float number = Random.Range(0, �ܦ��v��[0] + �ܦ��v��[1]);
        if (number <= �ܦ��v��[0])
        {
            �ثe���A = NPC���A.�[��;
            �e�{�C��.SetTrigger("�[��");
        }
        else if
        (�ܦ��v��[0] < number && number <= �ܦ��v��[0] + �ܦ��v��[1])
        {
            �ثe���A = NPC���A.����;
            �ਭ��� = Quaternion.Euler(0, Random.Range(1, 5) * 90, 0);
            �e�{�C��.SetTrigger("����");
        }
    }
    void Update()
    {
        if (�Ȱ� == false)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
        switch (�ثe���A)
        {
            case NPC���A . �[��:
                if (Time.time - ���O�ɶ� > ���y���)
                {
                    �H�����A();
                }
                ���d��();
                break;
            case NPC���A . ����:
                transform.Translate(Vector3.forward * Time.deltaTime * ���ʳt��);
                transform.rotation = Quaternion.Slerp(transform.rotation, �ਭ���, �ਭ�t��);

                if (Time.time - ���O�ɶ� > ���y���)
                {

                    �H�����A();
                }
                ���ޤ�();
                break;
            case NPC���A . ĵ��:
                if (!����)
                {
                    �e�{�C��.SetTrigger("ĵ��");
                    ���� = true;
                }
                transform.Translate(Vector3.forward * Time.deltaTime * ���ʳt��);
                �ਭ��� = Quaternion.LookRotation(���a.transform.position - transform.position, Vector3.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, �ਭ���, �ਭ�t��);
                ĵ�٤�();
                break;
            case NPC���A . �l��:
                if (!�]�B)
                {
                    �]�B = true;
                }
                transform.Translate(Vector3.forward * Time.deltaTime * ���ʳt�� * 4);
                �ਭ��� = Quaternion.LookRotation(���a.transform.position - transform.position, Vector3.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, �ਭ���, �ਭ�t��);
                �l����();
                break;
            case NPC���A . ��^:
                transform.Translate(Vector3.forward * Time.deltaTime * ���ʳt�� * 4);
                �ਭ��� = Quaternion.LookRotation(��l�y�� - transform.position, Vector3.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, �ਭ���, �ਭ�t��);
                ��^��();
                break;
        }
    }
    void ���d��()
    {

        �¯ٶZ�� = Vector3.Distance(���a.transform.position, transform.position);
        if (�¯ٶZ�� < �����d��)
        {
            SceneManager.LoadScene("L2");
            �Ȱ� = true;
            print("�i�JL2");
        }
        else if (�¯ٶZ�� < �۽åb�|)
        {
            �ثe���A = NPC���A.�l��;
            �e�{�C��.SetTrigger("�l��");
        }
        else if (�¯ٶZ�� < ĵ�٥b�|)
        {
            �ثe���A = NPC���A.ĵ��;
            �e�{�C��.SetTrigger("ĵ��");
        }
        else if (�¯ٶZ�� < �C���b�|)
        {
            �ثe���A = NPC���A.����;
            �ਭ��� = Quaternion.LookRotation(��l�y�� - transform.position, Vector3.up);
            �e�{�C��.SetTrigger("����");
        }
    }
    void ���ޤ�()
    {

        �¯ٶZ�� = Vector3.Distance(���a.transform.position, transform.position);
        ��^�Z�� = Vector3.Distance(transform.position, ��l�y��);
        if (�¯ٶZ�� < �����d��)
        {
            SceneManager.LoadScene("L2");
            �Ȱ� = true;
            print("�i�JL2");
        }
        else if (�¯ٶZ�� < �۽åb�|)
        {
            �ثe���A = NPC���A.�l��;
            �e�{�C��.SetTrigger("�l��");
        }
        else if (�¯ٶZ�� < ĵ�٥b�|)
        {
            �ثe���A = NPC���A.ĵ��;
            �e�{�C��.SetTrigger("ĵ��");
        }
        if (��^�Z�� > �C���b�|)
        {
            �ਭ��� = Quaternion.LookRotation(��l�y�� - transform.position, Vector3.up);
        }
    }
    void ��^��()
    {
        ��^�Z�� = Vector3.Distance(transform.position, ��l�y��);
        if (��^�Z�� < 1.5f)
        {

            �e�{�C��.SetTrigger("����");

            �]�B = false;
            �H�����A();
        }
    }
    void ĵ�٤�()
    {

        �Q��.gameObject.SetActive(true);
        �¯ٶZ�� = Vector3.Distance(���a.transform.position, transform.position);
        if (�¯ٶZ�� < �۽åb�|)
        {
            ���� = false;
            �Q��.gameObject.SetActive(false);
            �ثe���A = NPC���A.�l��;
            �e�{�C��.SetTrigger("�l��");
        }
        if (�¯ٶZ�� > ĵ�٥b�|)
        {
            ���� = false;
            �Q��.gameObject.SetActive(false);
            �H�����A();
            �e�{�C��.SetTrigger("�[��");
        }
    }
    void �l����()
    {

        �¯ٶZ�� = Vector3.Distance(���a.transform.position, transform.position);
        ��^�Z�� = Vector3.Distance(transform.position, ��l�y��);
        if (�¯ٶZ�� < �����d��)
        {
            SceneManager.LoadScene("L2");
            �Ȱ� = true;
            print("�i�JL2");
        }
        if (��^�Z�� > �l���b�| || �¯ٶZ�� > ĵ�٥b�|)
        {
            �ثe���A = NPC���A.��^;
            �e�{�C��.SetTrigger("��^");
        }
    }
}
