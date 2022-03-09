using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class FadeScript : MonoBehaviour
{
    //�A�j���[�^�[
    [SerializeField] private Animator _animator;

    // �A�j���[�^�[�R���g���[���[�̃��C���[(�ʏ��0)
    [SerializeField] private int _layer;

    //IsfadeStart�t���O
    private static readonly int ParamIsfadeStart = Animator.StringToHash("IsfadeStart");

    //fadeInisdone�t���O
    private static readonly int fadeInisdone = Animator.StringToHash("fadeInisdone");

    //�t�F�[�h�t���O�������Ă��邩
    public static bool isFadeOut = false;
    public static bool isFadeIn = false;

    //�A�j���[�V���������ǂ���
    public bool IsTransition { get; private set; }

    //�t�F�[�h�C��
    public void fade()
    {
        //�s������h�~
        if (IsTransition) return;

        //IsfadeStart�t���O���Z�b�g
        _animator.SetBool(ParamIsfadeStart, true);

        //�A�j���[�V�����ҋ@
        StartCoroutine(("start"));
    }

    // �J�A�j���[�V�����̑ҋ@�R���[�`��
    private IEnumerator WaitAnimation(string stateName, UnityAction onCompleted = null)
    {
        IsTransition = true;

        yield return new WaitUntil(() =>
        {
            // �X�e�[�g���ω����A�A�j���[�V�������I������܂Ń��[�v
            var state = _animator.GetCurrentAnimatorStateInfo(_layer);
            return state.IsName(stateName) && state.normalizedTime >= 1;
        });

        IsTransition = false;

        onCompleted?.Invoke();
    }
}

