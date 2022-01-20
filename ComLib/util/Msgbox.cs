using System;
using System.Reflection;
using System.Windows.Forms;

namespace ComLib
{
	/// <summary>
	/// �A�v���P�[�V�������ʃ��b�Z�[�W�N���X
	/// </summary>
	public static class Msgbox
	{
		/// <summary>
		/// ��񃁃b�Z�[�W�{�b�N�X�̕\��
		/// </summary>
		/// <param name="prf">�e�t�H�[��</param>
		/// <param name="ms">�\�����b�Z�[�W</param>
		public static void Info( Form prf, string ms  ){
			MessageBox.Show(prf,ms,"���",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);
		}
		/// <summary>
		/// ��񃁃b�Z�[�W�{�b�N�X�̕\��
		/// </summary>
		/// <param name="ms">�\�����b�Z�[�W</param>
		public static void Info( string ms){
			MessageBox.Show(ms,"���",
				MessageBoxButtons.OK,
				MessageBoxIcon.Information);
		}

		/// <summary>
		/// �x�����b�Z�[�W�{�b�N�X�̕\��
		/// </summary>
		/// <param name="prf">�e�t�H�[��</param>
		/// <param name="ms">�\�����b�Z�[�W</param>
		public static void Warning( Form prf, string ms ){
			MessageBox.Show(prf,ms,"�x��",
				MessageBoxButtons.OK,
				MessageBoxIcon.Warning);
		}
		/// <summary>
		/// �x�����b�Z�[�W�{�b�N�X�̕\��
		/// </summary>
		/// <param name="ms">�\�����b�Z�[�W</param>
		public static void Warning( string ms ){
			MessageBox.Show(ms,"�x��",
				MessageBoxButtons.OK,
				MessageBoxIcon.Warning);
		}

		/// <summary>
		/// �G���[���b�Z�[�W�{�b�N�X�̕\��
		/// </summary>
		/// <param name="prf">�e�t�H�[��</param>
		/// <param name="ms">�\�����b�Z�[�W</param>
		public static void Error( Form prf, string ms ){
			MessageBox.Show(prf,ms,"�G���[",
				MessageBoxButtons.OK,
				MessageBoxIcon.Error);
		}
		/// <summary>
		/// �G���[���b�Z�[�W�{�b�N�X�̕\��
		/// </summary>
		/// <param name="ms">�\�����b�Z�[�W</param>
		public static void Error( string ms ){
			MessageBox.Show(ms, "�G���[",
				MessageBoxButtons.OK,
				MessageBoxIcon.Error);
		}

		/// <summary>
		/// ���⃁�b�Z�[�W�{�b�N�X�̕\��
		/// </summary>
		/// <param name="prf">�e�t�H�[��</param>
		/// <param name="ms">�\�����b�Z�[�W</param>
		/// <returns>����</returns>
		public static DialogResult Question(Form prf, string ms)
		{
			return MessageBox.Show(
					prf,ms,"����",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Question,
					MessageBoxDefaultButton.Button1
				);
		}
		/// <summary>
		/// ���⃁�b�Z�[�W�{�b�N�X�̕\��
		/// </summary>
		/// <param name="ms">�\�����b�Z�[�W</param>
		/// <returns>����</returns>
		public static DialogResult Question( string ms ){
			return MessageBox.Show(
					ms, "����",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Question,
					MessageBoxDefaultButton.Button1
				);
		}

	}
}
