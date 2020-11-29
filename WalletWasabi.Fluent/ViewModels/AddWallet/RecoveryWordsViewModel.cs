using System.Collections.Generic;
using NBitcoin;
using ReactiveUI;
using WalletWasabi.Blockchain.Keys;
using WalletWasabi.Fluent.ViewModels.Navigation;
using WalletWasabi.Wallets;

namespace WalletWasabi.Fluent.ViewModels.AddWallet
{
	public class RecoveryWordsViewModel : RoutableViewModel
	{
		public RecoveryWordsViewModel(
			KeyManager keyManager,
			Mnemonic mnemonic,
			WalletManager walletManager)
		{
			MnemonicWords = new List<RecoveryWordViewModel>();

			for (int i = 0; i < mnemonic.Words.Length; i++)
			{
				MnemonicWords.Add(new RecoveryWordViewModel(i + 1, mnemonic.Words[i]));
			}

			NextCommand = ReactiveCommand.Create(
				() => NavigateTo(new ConfirmRecoveryWordsViewModel(MnemonicWords, keyManager, walletManager)));

			CancelCommand = ReactiveCommand.Create(() => ClearNavigation());
		}

		public List<RecoveryWordViewModel> MnemonicWords { get; set; }
	}
}