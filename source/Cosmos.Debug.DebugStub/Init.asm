; Generated at 11/14/2016 8:42:34 PM


	DebugStub_DebugBPs dd 0
	DebugStub_MaxBPId dd 0


		DebugStub_Init:
			Call DebugStub_Cls
			Call DebugStub_DisplayWaitMsg
			Call DebugStub_InitSerial
			Call DebugStub_WaitForDbgHandshake
			Call DebugStub_Cls

		DebugStub_Init_Exit:
			mov dword [static_field__Cosmos_Core_INTs_mLastKnownAddress], DebugStub_Init_Exit
			Ret


		DebugStub_WaitForSignature:
			mov dword EBX, 0x0

		DebugStub_WaitForSignature_Block1_Begin:
			cmp dword EBX, DebugStub_Const_Signature
			JE near DebugStub_WaitForSignature_Block1_End
			Call DebugStub_ComReadAL
			mov byte BL, AL
			ror dword EBX, 0x8
			Jmp DebugStub_WaitForSignature_Block1_Begin

		DebugStub_WaitForSignature_Block1_End:

		DebugStub_WaitForSignature_Exit:
			mov dword [static_field__Cosmos_Core_INTs_mLastKnownAddress], DebugStub_WaitForSignature_Exit
			Ret


		DebugStub_WaitForDbgHandshake:
			mov byte AL, 0x0
			Call DebugStub_ComWriteAL
			mov byte AL, 0x0
			Call DebugStub_ComWriteAL
			mov byte AL, 0x0
			Call DebugStub_ComWriteAL
			push dword DebugStub_Const_Signature
			mov dword ESI, ESP
			Call DebugStub_ComWrite32
			pop dword EAX
			mov byte AL, DebugStub_Const_Ds2Vs_Started
			Call DebugStub_ComWriteAL
			Call DebugStub_WaitForSignature
			Call DebugStub_ProcessCommandBatch
			Call DebugStub_Hook_OnHandshakeCompleted

		DebugStub_WaitForDbgHandshake_Exit:
			mov dword [static_field__Cosmos_Core_INTs_mLastKnownAddress], DebugStub_WaitForDbgHandshake_Exit
			Ret

			%ifndef Exclude_Dummy_Hooks

		DebugStub_Hook_OnHandshakeCompleted:

		DebugStub_Hook_OnHandshakeCompleted_Exit:
			mov dword [static_field__Cosmos_Core_INTs_mLastKnownAddress], DebugStub_Hook_OnHandshakeCompleted_Exit
			Ret

			%endif

