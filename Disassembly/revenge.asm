
; *******************************************************

	page 0
.L000
	xcall L1ea             		        ; $000: $1e $ea    //
	tcy   3                          ; $003: $4c        // Set R3 to logic 1.
	setr                             ; $007: $0d        //
	xbr   L340                       ; $00f: $1b $80    //

.L03f
	tcy   8                          ; $03f: $41        // Read 3:8
	tma                              ; $03e: $21        //
	alec  0                          ; $03d: $70        //
	br    L000                       ; $03b: $80        // If 0 reset
	xcall CalculateLogApprox         ; $037: $17 $c2    //
	tcy   8                          ; $01e: $41        //
	tma                              ; $03c: $21        //
	alec  3                          ; $039: $7c        //
	br    L000                       ; $033: $80        //
	alec  4                          ; $027: $72        //
	br    CheckWhichGame             ; $00e: $ac        //
	alec  5                          ; $01d: $7a        //
	br    L012                       ; $03a: $92        //
	alec  6                          ; $035: $76        //
	br    L008                       ; $02b: $88        //
	br    L000                       ; $016: $80        //
														
; ***********************************************************************************
;
;       Check which game is selected.
;
; ***********************************************************************************
.CheckWhichGame
	tcy   3                          ; $02c: $4c        // R3 is marked N/C ???
	rstr                             ; $018: $0c        //
	tcy   0                          ; $030: $40        // Access the Game Switches (28)
	setr                             ; $021: $0d        //
	tka                              ; $002: $08        // Read the game switch state.
	rstr                             ; $005: $0c        //
	tcy   10                         ; $00b: $45        //
	alec  1                          ; $017: $78        // if K1 is selected select game 1
	br    Game1Selected              ; $02e: $8d        //
	alec  3                          ; $01c: $7c        // if K2 is selected select game 2
	br    Game2Selected              ; $038: $b6        //
	alec  7                          ; $031: $7e        // if K4 is selected select game 3
	br    Game3Selected              ; $023: $9a        //
	br    SelectedUnknown            ; $006: $a9        // No idea which is selected.
;
; Store game selected in [3:10] as 1,2 or 5.
;
.Game1Selected
	tcmiy 1                          ; $00d: $68        // Set to 1 for Game 1
	br    L022                       ; $01b: $a2        //
.Game2Selected
	tcmiy 2                          ; $036: $64        // Set to 2 for Game 2
	br    L022                       ; $02d: $a2        //
.Game3Selected
	tcmiy 5                          ; $01a: $6a        // Set to 5 for Game 3 (?)
	br    L022                       ; $034: $a2        //
.SelectedUnknown
	br    Game1Selected              ; $029: $8d

.L012
	xbr   L3FA                       ; $012: $1f $ba    //
.L008
	xbr   L3d6                       ; $008: $1f $96    //
;
; Various setup stuff TBC.
;
.L022
	tcy   0                          ; $022: $40        //
	tcmiy 0                          ; $004: $60        // [3:0] <-0
	tcmiy 0                          ; $009: $60        // [3:1] <- 0
.L013
	tcy   4                          ; $013: $42        //
	tcmiy 0                          ; $026: $60        // [3:4] <- 0
	tcmiy 0                          ; $00c: $60        // [3:5] <- 0
	tcy   9                          ; $019: $49        //
	sbit  0                          ; $032: $30        // [3:9] set bit 0, clear bit 1.
	rbit  1                          ; $025: $36        //
	xbr   L180                       ; $00a: $16 $80    //

.L02a
	xcall WriteToPageSequential      ; $02a: $11 $c0    //
	xbr   L012                       ; $028: $10 $92    //

	comx                             ; $020: $00        //

; *******************************************************

	page 1
.L040
	xcall PresetTimer2560            ; $040: $1f $c6    // Preset the timer
.L043
	xcall L1ea             		        ; $043: $1e $ea    // Bump this....
	xcall DecrementTimer             ; $04f: $1f $e4    //  Decrement the timer.
	tcy   9                          ; $07f: $49        //
	tbit1 2                          ; $07e: $39        //
	br    L054                       ; $07d: $94        //  If timed out go here.
	xbr   L340                       ; $07b: $1b $80    //

.L06f
	tcy   8                          ; $06f: $41        // Read 3:8
	tma                              ; $05e: $21        //
	alec  0                          ; $07c: $70        // If zero
	br    L043                       ; $079: $83        // go back to decrementing the timer.

	xcall CalculateLogApprox         ; $073: $17 $c2    //

	tcy   8                          ; $04e: $41        //
	tma                              ; $05d: $21        //
	alec  4                          ; $07a: $72        //
	br    L056                       ; $075: $96        //

	br    L043                       ; $06b: $83        //
.L056
	alec  3                          ; $056: $7c        //
	br    L061                       ; $06c: $a1        //
	xbr   CheckWhichGame             ; $058: $10 $ac    //
.L061
	tcy   9                          ; $061: $49        //
	tbit1 0                          ; $042: $38        //
	br    L06e                       ; $045: $ae        //
	xbr   L09c                       ; $04b: $14 $9c    //
.L06e
	tcy   10                         ; $06e: $45        //
	tma                              ; $05c: $21        //
	alec  2                          ; $078: $74        //
	br    L049                       ; $071: $89        //
	alec  3                          ; $063: $7c        //
	br    L06d                       ; $046: $ad        //
	alec  4                          ; $04d: $72        //
	br    L064                       ; $05b: $a4        //
	br    L049                       ; $076: $89        //
.L06d
	tcy   15                         ; $06d: $4f        //
	xcall L189                       ; $05a: $16 $c9    //
	alec  0                          ; $069: $70        //
	br    L043                       ; $052: $83        //
.L064
	tcy   14                         ; $064: $47        //
	xcall L189                       ; $048: $16 $c9    //
	alec  0                          ; $062: $70        //
	br    L043                       ; $044: $83        //
.L049
	xcall ReadBank0                  ; $049: $15 $c0   // Read bank 0 into 2:0
	tcy   8                          ; $066: $41        // Read current, 3:8
	tma                              ; $04c: $21        //
	ldx   2                          ; $059: $3d        // Check if its the same as the bank value.
	tcy   0                          ; $072: $40        //
	saman                            ; $065: $27        //
	ldx   3                          ; $04a: $3f        // Get ready to process.
	xbr   L080                       ; $055: $14 $80    // Same

.L054
	xbr   L100                       ; $054: $12 $80    // Different.
	comx                             ; $050: $00        //
	comx                             ; $060: $00        //

; *******************************************************

	page 2
.L080
	alec  0                          ; $080: $70        //
	br    L08f                       ; $081: $8f        //
	xbr   L100                       ; $083: $12 $80    //
.L08f
	xbr   L1f1                       ; $08f: $1e $b1    //
.L0bf
	tcy   0                          ; $0bf: $40        //
	tma                              ; $0be: $21        //
	tcy   4                          ; $0bd: $42        //
	saman                            ; $0bb: $27        //
	alec  0                          ; $0b7: $70        //
	br    L0b9                       ; $0af: $b9        //
	xbr   L040                       ; $09e: $18 $80    //
.L0b9
	tcy   1                          ; $0b9: $48        //
	tma                              ; $0b3: $21        //
	tcy   5                          ; $0a7: $4a        //
	saman                            ; $08e: $27        //
	alec  0                          ; $09d: $70        //
	br    L096                       ; $0ba: $96        //
	xbr   L040                       ; $0b5: $18 $80    //
.L096
	tcy   10                         ; $096: $45        //
	tma                              ; $0ac: $21        //
	alec  1                          ; $098: $78        //
	br    L085                       ; $0b0: $85        //
	xbr   L0c0                       ; $0a1: $1c $80    //
.L085
	tcy   9                          ; $085: $49        //
	rbit  0                          ; $08b: $34        //
	xbr   L040                       ; $097: $18 $80    //
.L09c
	ldx   2                          ; $09c: $3d        //
	tcy   0                          ; $0b8: $40        //
	tam                              ; $0b1: $03        //
	xcall WriteToPageSequential      ; $0a3: $11 $c0    //
	xbr   L1f1                       ; $08d: $1e $b1    //
.L0b6
	tcy   4                          ; $0b6: $42        //
	tcmiy 0                          ; $0ad: $60        //
	tcmiy 0                          ; $09a: $60        //
	tcy   9                          ; $0b4: $49        //
	tcmiy 1                          ; $0a9: $68        //
	xbr   L040                       ; $092: $18 $80    //

.L088
	tcy   9                          ; $088: $49        // Set bit 1 of 2:9
	sbit  1                          ; $091: $32        //
	ldx   2                          ; $0a2: $3d        // Point to 2:0
	tcy   0                          ; $084: $40        //
	tcmiy 4                          ; $089: $62        // Play sound 4
	tcmiy 15                         ; $093: $6f        // Length 15
	xcall LightOnAndSetup            ; $0a6: $1d $c0    // Set up sound
	xcall SoundPlay                  ; $099: $13 $c0    // And do it.
	xcall L1c0                       ; $0a5: $1e $c0    //
	xbr   L3cb                       ; $095: $1f $8b    //

.L094
	tcy   10                         ; $094: $45        //
	tcmiy 0                          ; $0a8: $60        //
	xbr   L215                       ; $090: $11 $95    //

; *******************************************************

	page 3
.L0c0
	xcall PresetTimer2560            ; $0c0: $1f $c6    // Reset the timer
.L0c3
	xcall DecrementTimer             ; $0c3: $1f $e4    // Decrement it
	xcall PutAPlus4InY               ; $0cf: $11 $cc    // Waste time
	tcy   9                          ; $0ff: $49        //
	tbit1 2                          ; $0fe: $39        //
	br    L0f7                       ; $0fd: $b7        // Exit on time out
	br    L0c3                       ; $0fb: $83        //

.L0f7
	tcy   10                         ; $0f7: $45        // Read 3:10
	tma                              ; $0ef: $21        //
	alec  2                          ; $0de: $74        //
	br    GetDifficulty              ; $0fc: $ab        //
	tcy   9                          ; $0f9: $49        //
	tbit1 1                          ; $0f3: $3a        //
	br    L0fa                       ; $0e7: $ba        //
.ExitDifficulty
	xbr   L013                       ; $0ce: $10 $93    //
.L0fa
	xbr   L022                       ; $0fa: $10 $a2    //

; ***********************************************************************************
;
;       Read the difficulty switch.
;
; ***********************************************************************************
.GetDifficulty
	tcy   9                          ; $0eb: $49        // R9 is connected to the difficulty switch, I reckon.
	setr                             ; $0d6: $0d        // Set the line high
	tka                              ; $0ec: $08        // read the difficulty level switches into K1-K8
	rstr                             ; $0d8: $0c        // Set line low
	alec  1                          ; $0f0: $78        // If Level 1 leave unchanged
	br    ExitDifficulty             ; $0e1: $8e        //
	alec  3                          ; $0c2: $7c        // Handle Level 2
	br    Level2Difficulty           ; $0c5: $9c        //
	alec  7                          ; $0cb: $7e        // Handle Level 3
	br    Level3Difficulty           ; $0d7: $b1        //
	br    Level4Difficulty           ; $0ee: $86        // Level 4
.Level2Difficulty
	tcy   4                          ; $0dc: $42        //
	br    ProcessDifficulty          ; $0f8: $8d        //
.Level3Difficulty
	tcy   7                          ; $0f1: $4e        //
	br    ProcessDifficulty          ; $0e3: $8d        //
.Level4Difficulty
	tcy   10                         ; $0c6: $45        //
.ProcessDifficulty
	tya                              ; $0cd: $23        // Put Y into A (e.g. the difficulty constant)
	tcy   1                          ; $0db: $48        // access [3:1], position in sequential write.
	saman                            ; $0f6: $27        // Subtract difficulty from this value.
	alec  0                          ; $0ed: $70        //
	br    L0e9                       ; $0da: $a9        // Set if Y difficulty < [3:1]
	br    ExitDifficulty             ; $0f4: $8e        // Exit difficulty as is.
.L0e9
	xbr   L094                       ; $0e9: $14 $94    //



.L0e4
	tcy   10                         ; $0e4: $45        //
	tma                              ; $0c8: $21        //
	alec  0                          ; $0d1: $70        //
	br    L0d9                       ; $0e2: $99        //
	tcy   0                          ; $0c4: $40        //
	tbit1 2                          ; $0c9: $39        //
	br    L0e5                       ; $0d3: $a5        //
	xbr   L06f                       ; $0e6: $18 $af    //
.L0d9
	xbr   L03f                       ; $0d9: $10 $bf    //
.L0e5
	rbit  2                          ; $0e5: $35        //
	xbr   L1d1                       ; $0ca: $1e $91    //
	dyn                              ; $0ea: $2c        //
	comx                             ; $0d4: $00        //
	comx                             ; $0e8: $00        //
	comx                             ; $0d0: $00        //
	comx                             ; $0e0: $00        //

; *******************************************************

	page 4
.L100
	tcy   10                         ; $100: $45        //
	dman                             ; $101: $2a        //
	tam                              ; $103: $03        //
	tcy   9                          ; $107: $49        //
	tbit1 2                          ; $10f: $39        //
	br    L13b                       ; $11f: $bb        //
	tcy   8                          ; $13f: $41        //
	tma                              ; $13e: $21        //
	br    L11d                       ; $13d: $9d        //
.L13b
	tbit1 0                          ; $13b: $38        //
	br    L11e                       ; $137: $9e        //
	br    L12c                       ; $12f: $ac        //
.L11e
	xcall ReadBank0                  ; $11e: $15 $c0    // Read bank into 2:0
	ldx   2                          ; $139: $3d        // Read that value in.
	tcy   0                          ; $133: $40        //
	tma                              ; $127: $21        //
	ldx   3                          ; $10e: $3f        // Point back to 3
.L11d
	tcy   14                         ; $11d: $47        // Write that value to 3:14
	tam                              ; $13a: $03        //
	xcall PutAPlus4InY               ; $135: $11 $cc    //
	setr                             ; $116: $0d        //
.L12c
	xbr   L088                       ; $12c: $14 $88    //
.L130
	tcy   14                         ; $130: $47        //
	tma                              ; $121: $21        //
	xcall PutAPlus4InY               ; $102: $11 $cc    //
	rstr                             ; $10b: $0c        //
	tcy   14                         ; $117: $47        //
	tma                              ; $12e: $21        //
	tcy   10                         ; $11c: $45        // Read game into Y
	tmy                              ; $138: $22        //
	ldx   2                          ; $131: $3d        //
	ynec  4                          ; $123: $52        //
	br    L136                       ; $106: $b6        //
	tcy   14                         ; $10d: $47        //
	br    L134                       ; $11b: $b4        //
.L136
	ynec  3                          ; $136: $5c        //
	br    L108                       ; $12d: $88        //
	tcy   15                         ; $11a: $4f        //
.L134
	tam                              ; $134: $03        //
	ldx   3                          ; $129: $3f        //
	xbr   L0c0                       ; $112: $1c $80    //
.L108
	ynec  2                          ; $108: $54        //
	br    L10a                       ; $111: $8a        //
	tcy   13                         ; $122: $4b        //
	tam                              ; $104: $03        //
	ldx   3                          ; $109: $3f        //
	tcy   10                         ; $113: $45        //
	tcmiy 0                          ; $126: $60        //
	tcy   12                         ; $10c: $43        //
	tcmiy 0                          ; $119: $60        //
	xbr   L180                       ; $132: $16 $80    //
.L10a
	ldx   3                          ; $10a: $3f        //
	tcy   10                         ; $115: $45        //
	tcmiy 0                          ; $12a: $60        //
	xbr   L000                       ; $114: $10 $80    //
	tdo                              ; $110: $0a        //
	comx                             ; $120: $00        //

; *******************************************************

	page 5
.L140
	ldx   3                          ; $140: $3f        // Read current game into A
	tcy   10                         ; $141: $45        //
	tma                              ; $143: $21        //
	alec  1                          ; $147: $78        // Game 1
	br    Game1Code                  ; $14f: $b1        //
	alec  2                          ; $15f: $74        //
	br    Game2Code                  ; $17f: $bb        // Game 2
	alec  4                          ; $17e: $72        //
	br    Game3Code                  ; $17d: $b9        // Game 3 ? (5)

.Game2Code
	tcy   1                          ; $17b: $48        // Copy 3:1 to 3:11
	tma                              ; $177: $21        //
	tcy   11                         ; $16f: $4d        //
	tam                              ; $15e: $03        //
	br    L175                       ; $17c: $b5        //
.Game3Code
	tcy   1                          ; $179: $48        // Copy 3:1 to 3:11 if 3:1 <= 3:11
	tma                              ; $173: $21        //
	tcy   11                         ; $167: $4d        //
	alem                             ; $14e: $29        //
	br    L175                       ; $15d: $b5        //
	tam                              ; $17a: $03        //
.L175
	tma                              ; $175: $21        //
	ldx   2                          ; $16b: $3d        //
	tcy   1                          ; $156: $48        //
	alec  0                          ; $16c: $70        //
	br    L15c                       ; $158: $9c        //
	alec  2                          ; $170: $74        //
	br    Game1Code                  ; $161: $b1        //
	alec  4                          ; $142: $72        //
	br    L15b                       ; $145: $9b        //
	alec  6                          ; $14b: $76        //
	br    L16d                       ; $157: $ad        //
	br    L174                       ; $16e: $b4        //
.L15c
	tcmiy 7                          ; $15c: $6e        //
	br    L169                       ; $178: $a9        //
.Game1Code
	ldx   2                          ; $171: $3d        //
	tcy   1                          ; $163: $48        //
	tcmiy 5                          ; $146: $6a        //
	br    L169                       ; $14d: $a9        //
.L15b
	tcmiy 4                          ; $15b: $62        //
	br    L169                       ; $176: $a9        //
.L16d
	tcmiy 3                          ; $16d: $6c        //
	br    L169                       ; $15a: $a9        //
.L174
	tcmiy 2                          ; $174: $64        //
.L169
	retn                             ; $169: $0f        //

; ***********************************************************************************
;
; Game over code. Plays notes 8-0 in order alternating with the note in 3:8
;
; ***********************************************************************************

.GameOverCode
	tcy   4                          ; $152: $42        // Set 3:4 to 8
	tcmiy 8                          ; $164: $61        //
.GameOverPlayCorrectNext
	tcy   4                          ; $148: $42        // Read 3:4
	dman                             ; $151: $2a        // Decrement it.
	br    PlayingEndNoise            ; $162: $89        // Keep going until it is zero.
	br    GoToRestart                ; $144: $a8        // Finished playing the sequence, restart.
.PlayingEndNoise
	tam                              ; $149: $03        // Store back in 3:4
	ldx   2                          ; $153: $3d        // Play sound 5 for length 1 (End game)
	tcy   0                          ; $166: $40        //
	tcmiy 5                          ; $14c: $6a        //
	tcmiy 1                          ; $159: $68        //
	xcall LightOnAndSetup            ; $172: $1d $c0    // Play that sound
	xcall SoundPlay                  ; $14a: $13 $c0    //
	xbr   GameOverPlayCorrect        ; $16a: $11 $b6    // Plays [3:8] with lights.
.GoToRestart
	xbr   L000                       ; $168: $10 $80    //

	ynea                             ; $160: $02        //

; *******************************************************

	page 6
.L180
	tcy   8                          ; $180: $41        // Zero 3:8
	tcmiy 0                          ; $181: $60        //
	tcy   12                         ; $183: $43        //
	tma                              ; $187: $21        //
	tcy   14                         ; $18f: $47        //
	tam                              ; $19f: $03        //
	rbit  2                          ; $1bf: $35        //
	rbit  3                          ; $1be: $37        //
.L1bd
	tcy   10                         ; $1bd: $45        // Read current game into A
	tma                              ; $1bb: $21        //
	alec  0                          ; $1b7: $70        //
	br    L1ba                       ; $1af: $ba        //
	alec  2                          ; $19e: $74        //
	br    L1ae                       ; $1bc: $ae        //
	alec  3                          ; $1b9: $7c        //
	br    L1ac                       ; $1b3: $ac        //
	alec  4                          ; $1a7: $72        //
	br    L182                       ; $18e: $82        //
	br    L1ae                       ; $19d: $ae        //
.L1ba
	tcy   13                         ; $1ba: $4b        //
	call  L189                       ; $1b5: $c9        //
	alec  0                          ; $1ab: $70        //
	br    L1a5                       ; $196: $a5        //
.L1ac
	tcy   15                         ; $1ac: $4f        //
	call  L189                       ; $198: $c9        //
	alec  0                          ; $1b0: $70        //
	br    L1a5                       ; $1a1: $a5        //
.L182
	tcy   14                         ; $182: $47        //
	call  L189                       ; $185: $c9        //
	alec  0                          ; $18b: $70        //
	br    L1a5                       ; $197: $a5        //
.L1ae
	tcy   14                         ; $1ae: $47        //
	dman                             ; $19c: $2a        //
	br    L1a3                       ; $1b8: $a3        //
	br    L1b4                       ; $1b1: $b4        //
.L1a3
	tam                              ; $1a3: $03        //
	tcy   8                          ; $186: $41        //
	imac                             ; $18d: $28        //
	tam                              ; $19b: $03        //
	rbit  2                          ; $1b6: $35        //
	rbit  3                          ; $1ad: $37        //
	br    L1bd                       ; $19a: $bd        //
.L1b4
	tcy   10                         ; $1b4: $45        // Read current game into A
	tma                              ; $1a9: $21        //
	alec  0                          ; $192: $70        // Is it =0
	br    GameOver310Zero            ; $1a4: $a2        //
	xbr   L266                       ; $188: $19 $a6    //

.GameOver310Zero
	xbr   GameOverCode               ; $1a2: $1a $92    //

.L189
	ldx   2                          ; $189: $3d        // Read 2,Y
	tma                              ; $193: $21        //
	ldx   3                          ; $1a6: $3f        // Compare against 3,8
	tcy   8                          ; $18c: $41        //
	saman                            ; $199: $27        //
	retn                             ; $1b2: $0f        //
.L1a5
	imac                             ; $1a5: $28        //
	tam                              ; $18a: $03        //
	rbit  2                          ; $195: $35        //
	rbit  3                          ; $1aa: $37        //
	br    L1bd                       ; $194: $bd        //
	comx                             ; $1a8: $00        //
	comx                             ; $190: $00        //
	comx                             ; $1a0: $00        //

; *******************************************************

	page 7
.L1c0
	tcy   1                          ; $1c0: $48        // Read 3:1
	tma                              ; $1c1: $21        //
	tcy   3                          ; $1c3: $4c        // Calc 3:3-3:1
	saman                            ; $1c7: $27        //
	alec  0                          ; $1cf: $70        // Check if 3:3 == 3:1
	br    L1ef                       ; $1df: $af        //
	tma                              ; $1ff: $21        //
	tcy   1                          ; $1fe: $48        //
	alem                             ; $1fd: $29        //
	br    L1e7                       ; $1fb: $a7        //
	br    ReturnX3v2                 ; $1f7: $9c        //
.L1ef
	tcy   0                          ; $1ef: $40        // Read 3:0
	tma                              ; $1de: $21        //
	tcy   2                          ; $1fc: $44        //
	alem                             ; $1f9: $29        //
	br    ReturnX3v2                 ; $1f3: $9c        //
.L1e7
	tcy   0                          ; $1e7: $40        //
	tma                              ; $1ce: $21        //
	tcy   2                          ; $1dd: $44        //
	tam                              ; $1fa: $03        //
	tcy   1                          ; $1f5: $48        //
	tma                              ; $1eb: $21        //
	tcy   3                          ; $1d6: $4c        //
	tam                              ; $1ec: $03        //

	tcy   0                          ; $1d8: $40        // Now copy Page 0 to Page 1.
.CopyPage0Page1Loop
	ldx   0                          ; $1f0: $3c        // Read 0:Y
	tma                              ; $1e1: $21        //
	ldx   1                          ; $1c2: $3e        // Put in 1:Y
	tam                              ; $1c5: $03        //
	iyc                              ; $1cb: $2b        // Increment Y
	br    ReturnX3v2                 ; $1d7: $9c        // Complete then exit.
	br    CopyPage0Page1Loop         ; $1ee: $b0        //
.ReturnX3v2
	ldx   3                          ; $1dc: $3f        //
	retn                             ; $1f8: $0f        //


.L1f1
	tcy   1                          ; $1f1: $48        // Set length 2:1 to 1
	ldx   2                          ; $1e3: $3d        //
	tcmiy 1                          ; $1c6: $68        //
	xcall LightOnAndSetup            ; $1cd: $1d $c0    // Player light and sound.
	xcall SoundPlay                  ; $1f6: $13 $c0    //
	xcall LightCurrentOff            ; $1da: $1f $f7    //
	tcy   0                          ; $1e9: $40        //
	sbit  2                          ; $1d2: $31        //
	xbr   L340                       ; $1e4: $1b $80    //
.L1d1
	tcy   13                         ; $1d1: $4b        //
	tma                              ; $1e2: $21        //
	alec  0                          ; $1c4: $70        //
	br    L1e6                       ; $1c9: $a6        //
	br    L1f1                       ; $1d3: $b1        //
.L1e6
	tcy   9                          ; $1e6: $49        //
	tbit1 0                          ; $1cc: $38        //
	br    L1ca                       ; $1d9: $8a        //
	xbr   L0b6                       ; $1f2: $14 $b6    //
.L1ca
	xbr   L0bf                       ; $1ca: $14 $bf    //
.L1ea
	tcy   12                         ; $1ea: $43        //
	imac                             ; $1d4: $28        //
	tam                              ; $1e8: $03        //
	retn                             ; $1d0: $0f        //
	comx                             ; $1e0: $00        //

; ***********************************************************************************
;
;       Sequential Write to Page 0
;
;  3:0 bit 0 = 0 (upper bits) 1 (lower bits)
; 3:1 page address
; 3:8 (value 0-3)
;
; ***********************************************************************************

	page 8

.WriteToPageSequential
	ldx   3                          ; $200: $3f        // 3:0 bit 0 is LSB
	tcy   0                          ; $201: $40        //
	tbit1 0                          ; $203: $38        //
	br    WriteToLowerBits           ; $207: $a1        // if set go to LSB = 1 code.

	tcy   8                          ; $20f: $41        // Read 3:8 , the page offset into A
	tma                              ; $21f: $21        //
	tcy   0                          ; $23f: $40        // Set 3:0 to 1.
	tcmiy 1                          ; $23e: $68        //
	tmy                              ; $23d: $22        // Read 3:1
	ldx   0                          ; $23b: $3c        // Point to page
	alec  0                          ; $237: $70        // Write 0,4,8,12 depending on A being 0,1,2,3
	br    Write0ToPage0              ; $22f: $8e        //
	alec  1                          ; $21e: $78        //
	br    Write4ToPage0              ; $23c: $ba        //
	alec  2                          ; $239: $74        //
	br    Write8ToPage0              ; $233: $ab        //
	br    Write12ToPage0             ; $227: $ac        // Note these blank the upper pages.

.Write0ToPage0
	tcmiy 0                          ; $20e: $60        //
	br    ReturnWithX3               ; $21d: $98        //
.Write4ToPage0
	tcmiy 4                          ; $23a: $62        //
	br    ReturnWithX3               ; $235: $98        //
.Write8ToPage0
	tcmiy 8                          ; $22b: $61        //
	br    ReturnWithX3               ; $216: $98        //
.Write12ToPage0
	tcmiy 12                         ; $22c: $63        //
.ReturnWithX3
	ldx   3                          ; $218: $3f        //
	br    Return                     ; $230: $9b        //

.WriteToLowerBits
	tcy   8                          ; $221: $41        // Read 3:8 into A, the data.
	tma                              ; $202: $21        //
	tcy   0                          ; $205: $40        // Clear 3:0
	tcmiy 0                          ; $20b: $60        //
	tmy                              ; $217: $22        // Read 3:1 the address to write
	ldx   0                          ; $22e: $3c        //
	amaac                            ; $21c: $25        // Add value from 3:8 to 0:address
	tam                              ; $238: $03        // Write it back
	ldx   3                          ; $231: $3f        // Go back to the pointer at 3:1
	tcy   1                          ; $223: $48        //
	imac                             ; $206: $28        // Increment it and write it back.
	tam                              ; $20d: $03        //
.Return
	retn                             ; $21b: $0f
;
; Play note at 3:8 (current) and then go back.
;
.GameOverPlayCorrect
	tcy   8                          ; $236: $41        // Read 3:8
	tma                              ; $22d: $21        //
	ldx   2                          ; $21a: $3d        // Store it in 2:0 (current sound)
	tcy   0                          ; $234: $40        //
	tamiy                            ; $229: $20        //
	tcmiy 1                          ; $212: $68        // Set length to 1.
	xcall LightOnAndSetup            ; $224: $1d $c0    //
	xcall SoundPlay                  ; $211: $13 $c0    //
	xcall LightCurrentOff            ; $204: $1f $f7    //
	xbr   GameOverPlayCorrectNext    ; $213: $1a $88    //
;
; Add 4 to A, put in Y.
;
.PutAPlus4InY
	a6aac                            ; $20c: $06        //  Add 6 to A
	dan                              ; $219: $07        //  Subtract 1
	dan                              ; $232: $07        //  Subtract 1
	tay                              ; $225: $24        //  Put in Y
	retn                             ; $20a: $0f        //
;
; Part of the end game routine.
;
.L215
	xcall L1c0                       ; $215: $1e $c0    //
	ldx   2                          ; $214: $3d        //
	xbr   L295                       ; $228: $15 $95    //
	comx                             ; $220: $00        //

; *******************************************************

	page 9

.L240
	tcy   4                          ; $240: $42        // Read 3:4 to A
	tma                              ; $241: $21        //
	tcy   8                          ; $243: $41        // Read 3:8 to Y
	tmy                              ; $247: $22        //
	saman                            ; $24f: $27        // Does 3:4 match Page3[3:8]
	alec  0                          ; $25f: $70        //
	br    L27d                       ; $27f: $bd        //
	br    L279                       ; $27e: $b9        //
.L27d
	iyc                              ; $27d: $2b        //
	tma                              ; $27b: $21        //
	tcy   5                          ; $277: $4a        //
	saman                            ; $26f: $27        //
	alec  0                          ; $25e: $70        //
	br    L25a                       ; $27c: $9a        //
.L279
	ldx   2                          ; $279: $3d        //
	tcy   0                          ; $273: $40        //
	tcmiy 5                          ; $267: $6a        //
	xcall L140                       ; $24e: $1a $c0    //
	xcall LightOnAndSetup            ; $27a: $1d $c0    //
	xcall SoundPlay                  ; $26b: $13 $c0    //
	tcy   8                          ; $26c: $41        //
	tma                              ; $258: $21        //
	alec  0                          ; $270: $70        //
	br    L257                       ; $261: $97        //
	xcall ReadBank1                  ; $242: $15 $e3    //
	br    L25c                       ; $24b: $9c        //
.L257
	xcall ReadBank0                  ; $257: $15 $c0    //
.L25c
	xcall L140                       ; $25c: $1a $c0    //
	xcall LightOnAndSetup            ; $271: $1d $c0    //
	xcall SoundPlay                  ; $246: $13 $c0    //
	xcall LightCurrentOff            ; $25b: $1f $f7    //
	br    L240                       ; $26d: $80        //
.L25a
	tcy   4                          ; $25a: $42        //
	tcmiy 0                          ; $274: $60        //
	tcmiy 0                          ; $269: $60        //
	tcy   10                         ; $252: $45        //
	tma                              ; $264: $21        //
	alec  0                          ; $248: $70        //
	br    L249                       ; $251: $89        //
	xbr   L040                       ; $262: $18 $80    //
.L249
	xbr   L000                       ; $249: $10 $80    //

.L266
	tcy   0                          ; $266: $40        //
	setr                             ; $24c: $0d        //
	tka                              ; $259: $08        //
	rstr                             ; $272: $0c        //
	alec  7                          ; $265: $7e        //
	br    L254                       ; $24a: $94        //
	tcy   8                          ; $255: $41        //
	tcmiy 0                          ; $26a: $60        //
.L254
	xbr   L02a                       ; $254: $10 $aa    //
	tamza                            ; $250: $04        //
	ia                               ; $260: $0e        //

; ***********************************************************************************
;
;    2 Bit Read Bank 0 at position 3:5/3:4 (LSB only) store in 2:0
;
; ***********************************************************************************

	page 10
.ReadBank0
	tcy   4                          ; $280: $42        // Look at 3:4 (bit 0 is LSB of 5 bit sequence)
	tbit1 0                          ; $281: $38        // If bit 0 set
	br    AccessLowerBits            ; $283: $a7        // Look at bits 0 and 1
	tcmiy 1                          ; $287: $68        // Set bit 0 next time around.
	tmy                              ; $28f: $22        // Read 3:5 in which is bits 4,3,2,1 of 5 bit sequence
	ldx   0                          ; $29f: $3c        // Look at page 0 where the data is.
.ReadBankUpperBits
	tma                              ; $2bf: $21        // Read byte from page 0 [3:5]
	tcy   0                          ; $2be: $40        // Point to 2:0 where the result goes.
	ldx   2                          ; $2bd: $3d        //
	alec  3                          ; $2bb: $7c        // If byte read <= 3 e.g. 00xx
	br    Write0AndExit              ; $2b7: $84        //
	alec  7                          ; $2af: $7e        // If byte read <= 7 e.g. 01xx
	br    Write1AndExit              ; $29e: $93        //
	alec  11                         ; $2bc: $7d        // If byte read <= 11 e.g. 10xx
	br    Write2AndExit              ; $2b9: $8c        //
	br    Write3AndExit              ; $2b3: $b2        // Otherwise it is 11xx
;
; Access the lower bits.
;
.AccessLowerBits
	tcmiy 0                          ; $2a7: $60        // Bit 3:4[0] is set, clear it back to zero
	imac                             ; $28e: $28        // Increment 3[5], incrementing a 5 bit counter here.
	tam                              ; $29d: $03        // Write back
	dman                             ; $2ba: $2a        // Decrement to get the old value.
	tay                              ; $2b5: $24        // Put in Y
	ldx   0                          ; $2ab: $3c        // Access X:0
.ReadBankLowerBits
	tma                              ; $296: $21        // Read it in
	rbit  2                          ; $2ac: $35        // Mask with 00xx
	rbit  3                          ; $298: $37        //
	xma                              ; $2b0: $2e        // Fix old value back, A is now 0000-0011
	tcy   0                          ; $2a1: $40        // Point back to 2:0 where the result goes.
	ldx   2                          ; $282: $3d        //
	alec  0                          ; $285: $70        //
	br    Write0AndExit              ; $28b: $84        //
	alec  1                          ; $297: $78        //
	br    Write1AndExit              ; $2ae: $93        //
	alec  2                          ; $29c: $74        //
	br    Write2AndExit              ; $2b8: $8c        //
	br    Write3AndExit              ; $2b1: $b2        //

; ***********************************************************************************
;
;    2 Bit Read Bank 1 at position 3:5/3:4 (LSB only) store in 2:0
;
; ***********************************************************************************

.ReadBank1
	tcy   4                          ; $2a3: $42        // Look at 3:4 bit 0, the LSB
	tbit1 0                          ; $286: $38        //
	br    ReadBank1Lower             ; $28d: $b4        // Read Bank 1 lower if set.
	tcmiy 1                          ; $29b: $68        // Flip LSB
	tmy                              ; $2b6: $22        // Read LSB into Y
	ldx   1                          ; $2ad: $3e        // And read upper bank except use bank 1
	br    ReadBankUpperBits          ; $29a: $bf        //
.ReadBank1Lower
	tcmiy 0                          ; $2b4: $60        // Clear LSB in 3:4
	imac                             ; $2a9: $28        // Increment 3:5
	tam                              ; $292: $03        // Write back
	dman                             ; $2a4: $2a        // Get original value into Y
	tay                              ; $288: $24        //
	ldx   1                          ; $291: $3e        // And read lower bank except use bank 1
	br    ReadBankLowerBits          ; $2a2: $96        //

;
; Output final values for Bank Read.
;
.Write0AndExit
	tcmiy 0                          ; $284: $60        //
	br    ReadBankExit               ; $289: $a5        //
.Write1AndExit
	tcmiy 1                          ; $293: $68        //
	br    ReadBankExit               ; $2a6: $a5        //
.Write2AndExit
	tcmiy 2                          ; $28c: $64        //
	br    ReadBankExit               ; $299: $a5        //
.Write3AndExit
	tcmiy 3                          ; $2b2: $6c        //
.ReadBankExit
	ldx   3                          ; $2a5: $3f        //
	retn                             ; $28a: $0f        //

.L295
	tcy   0                          ; $295: $40        // Access the current in 2:0
	tma                              ; $2aa: $21        // Read it
	ldx   3                          ; $294: $3f        // Point to 3:8
	tcy   8                          ; $2a8: $41        //
	xbr   L328                       ; $290: $13 $a8    //

; ***********************************************************************************
;
;    Put the current light [2:0] on and/or set up for tone generation
;
; ***********************************************************************************

	page 11
.LightOnAndSetup
	ldx   2                          ; $2c0: $3d        // Access 2:0
	tcy   0                          ; $2c1: $40        //
	tma                              ; $2c3: $21        // Read this
	tcy   2                          ; $2c7: $44        // Point to 2:2
	alec  0                          ; $2cf: $70        //
	br    LightR4                    ; $2df: $b3        // if zero
	alec  1                          ; $2ff: $78        //
	br    LightR5                    ; $2fe: $ac        // if one
	alec  2                          ; $2fd: $74        //
	br    LightR6                    ; $2fb: $ae        // if two
	alec  3                          ; $2f7: $7c        //
	br    LightR7                    ; $2ef: $b6        // if three
	alec  4                          ; $2de: $72        //
	br    Stored4                    ; $2fc: $91        // if four ...... ?
	br    StoredOther                ; $2f9: $99        //
.LightR4
	tcmiy 1                          ; $2f3: $68        // Write 1,1,2,1,2,1  and set R4 = 1
	tcmiy 1                          ; $2e7: $68        //
	setr                             ; $2ce: $0d        //
	tcmiy 2                          ; $2dd: $64        //
	tcmiy 1                          ; $2fa: $68        //
	tcmiy 2                          ; $2f5: $64        //
	tcmiy 1                          ; $2eb: $68        //
	br    ExitLightSetup             ; $2d6: $94        //
.LightR5
	tcmiy 7                          ; $2ec: $6e        // Write 7,1,13,0,13,0 and set R5 = 1
	tcmiy 1                          ; $2d8: $68        //
	tcmiy 13                         ; $2f0: $6b        //
	setr                             ; $2e1: $0d        //
	tcmiy 0                          ; $2c2: $60        //
	tcmiy 13                         ; $2c5: $6b        //
	tcmiy 0                          ; $2cb: $60        //
	br    ExitLightSetup             ; $2d7: $94        //
.LightR6
	tcmiy 14                         ; $2ee: $67        // Write 14,1,10,0,10,0 and set R6 = 1
	tcmiy 1                          ; $2dc: $68        //
	tcmiy 10                         ; $2f8: $65        //
	tcmiy 0                          ; $2f1: $60        //
	setr                             ; $2e3: $0d        //
	tcmiy 10                         ; $2c6: $65        //
	tcmiy 0                          ; $2cd: $60        //
	br    ExitLightSetup             ; $2db: $94        //
.LightR7
	tcmiy 5                          ; $2f6: $6a        // Write 5,2,8,0,8,0 and set R7 = 1
	tcmiy 2                          ; $2ed: $64        //
	tcmiy 8                          ; $2da: $61        //
	tcmiy 0                          ; $2f4: $60        //
	tcmiy 8                          ; $2e9: $61        //
	setr                             ; $2d2: $0d        //
	tcmiy 0                          ; $2e4: $60        //
	br    ExitLightSetup             ; $2c8: $94        //
.Stored4
	tcmiy 10                         ; $2d1: $65        // Write 10,0,14,1,10,5
	tcmiy 0                          ; $2e2: $60        //
	tcmiy 14                         ; $2c4: $67        //
	tcmiy 1                          ; $2c9: $68        //
	tcmiy 10                         ; $2d3: $65        //
	tcmiy 5                          ; $2e6: $6a        //
	br    ExitLightSetup             ; $2cc: $94        //
.StoredOther
	tcmiy 2                          ; $2d9: $64        // Write 2,0,0,0,12,3
	tcmiy 0                          ; $2f2: $60        //
	tcmiy 0                          ; $2e5: $60        //
	tcmiy 0                          ; $2ca: $60        //
	tcmiy 12                         ; $2d5: $63        //
	tcmiy 3                          ; $2ea: $6c        //
.ExitLightSetup
	ldx   3                          ; $2d4: $3f        //
	retn                             ; $2e8: $0f        //
	a8aac                            ; $2d0: $01        //
	a10aac                           ; $2e0: $05        //

; ***********************************************************************************
;
;  Play sound 2:1 sound details 2:2 onwards counter copies 2:8 onwards.
;
; ***********************************************************************************

	page 12
.SoundPlay
	ldx   2                          ; $300: $3d        // [2:1] = Length ?
	tcy   1                          ; $301: $48        //
	dman                             ; $303: $2a        // Decrement counter
	br    SoundStillPlaying          ; $307: $9f        // If still playing
	br    ExitSound                  ; $30f: $aa        //
.SoundStillPlaying

	tamiy                            ; $31f: $20        // Copy the number of complete (e.g. on + off pulses)
	tma                              ; $33f: $21        // to sound from 2:2,2:3 to 2:8,2:9
	tcy   8                          ; $33e: $41        //
	tam                              ; $33d: $03        //
	tcy   3                          ; $33b: $4c        //
	tma                              ; $337: $21        //
	tcy   9                          ; $32f: $49        //
	tam                              ; $31e: $03        //
;
; Sound cycle loop. Does 2:8,2:9 times the on and off cycles.
;
.SoundOnOffCycle
	tcy   8                          ; $33c: $41        // Decrement 2:8,2:9
	dman                             ; $339: $2a        //
	br    SoundOnCycle               ; $333: $b5        //
	tamiy                            ; $327: $20        //
	dman                             ; $30e: $2a        //
	br    SoundOnCycle               ; $31d: $b5        //
	br    SoundPlay                  ; $33a: $80        //
;
; Reset the on cycle by copying (4,5) to (10,11)
;
.SoundOnCycle
	tam                              ; $335: $03        // Fix up decrement and Copy 2:4,2:5 to 2:10,2:11
	tcy   4                          ; $32b: $42        //
	tma                              ; $316: $21        //
	tcy   10                         ; $32c: $45        //
	tam                              ; $318: $03        //
	tcy   5                          ; $330: $4a        //
	tma                              ; $321: $21        //
	tcy   11                         ; $302: $4d        //
	tam                              ; $305: $03        //
;
; On Cycle Loop (2:10,2:11 times)
;
.SoundOnLoop
	tcy   10                         ; $30b: $45        // Decrement 2:10,2:11
	dman                             ; $317: $2a        //
	br    SoundOnContinue            ; $32e: $86        //
	tamiy                            ; $31c: $20        //
	dman                             ; $338: $2a        //
	br    SoundOnContinue            ; $331: $86        //
	br    SoundOffCycle              ; $323: $ad        //
.SoundOnContinue
	tam                              ; $306: $03        // Fix up decrement
	tcy   8                          ; $30d: $41        // Turn speaker on.
	setr                             ; $31b: $0d        //
	br    SoundOnLoop                ; $336: $8b        //
;
; Reset the off cycle by coping (6,7) -> (12,13)
;
.SoundOffCycle
	tcy   6                          ; $32d: $46        // Copy 2:6,2:7 to 2:12,2:13
	tma                              ; $31a: $21        //
	tcy   12                         ; $334: $43        //
	tam                              ; $329: $03        //
	tcy   7                          ; $312: $4e        //
	tma                              ; $324: $21        //
	tcy   13                         ; $308: $4b        //
	tam                              ; $311: $03        //
;
; Off cycle loop (2:12,13)
;
.SoundOffLoop
	tcy   12                         ; $322: $43        //  Decrement the inner loop [2:12,13]
	dman                             ; $304: $2a        //
	br    SoundOffContinue           ; $309: $b2        //
	tamiy                            ; $313: $20        //
	dman                             ; $326: $2a        //
	br    SoundOffContinue           ; $30c: $b2        //
	br    SoundOnOffCycle            ; $319: $bc        //
.SoundOffContinue
	tam                              ; $332: $03        // Fix up the result of the decrement
	tcy   8                          ; $325: $41        // Clear R8 (Speaker toggle)
	rstr                             ; $30a: $0c        //
	br    SoundOffLoop               ; $315: $a2        // Keep going round.
.ExitSound
	ldx   3                          ; $32a: $3f        //
	retn                             ; $314: $0f        //


.L328
	tam                              ; $328: $03        // Save it.
	xbr   GameOverCode               ; $310: $1a $92    //

; *******************************************************

	page 13
.L340
	tcy   8                          ; $340: $41        // [3:8] <- 0
	tcmiy 0                          ; $341: $60        //
	tcy   14                         ; $343: $47        // [3:14] <- 1
	tcmiy 1                          ; $347: $68        //
.L34f
	tcy   14                         ; $34f: $47        // Load 3:14 into Y, current scanning line.
	tmy                              ; $35f: $22        //
	setr                             ; $37f: $0d        // Read the line with that value set.
	tka                              ; $37e: $08        //
	rstr                             ; $37d: $0c        //
	alec  0                          ; $37b: $70        // Causes set flag if any line set.
	br    L348                       ; $377: $88        // No Key pressed if zero.
	tcy   0                          ; $36f: $40        // Set bit 2 of 3:0
	sbit  1                          ; $35e: $32        //
	tcy   6                          ; $37c: $46        // Copy bit pattern to 3:6
	tam                              ; $379: $03        //
	tcy   15                         ; $373: $4f        // Read 3:15
	tma                              ; $367: $21        //
	tcy   14                         ; $34e: $47        // Same as 3:14
	saman                            ; $35d: $27        //
	alec  0                          ; $37a: $70        //
	br    L342                       ; $375: $82        //
	tma                              ; $36b: $21        //
	tcy   15                         ; $356: $4f        // No, 3:14 to 3:15
	tam                              ; $36c: $03        //
	tcy   13                         ; $358: $4b        // Zero 3:13
	tcmiy 0                          ; $370: $60        //
	br    L348                       ; $361: $88        //
.L342
	tcy   13                         ; $342: $4b        //
	mnez                             ; $345: $26        //
	br    L371                       ; $34b: $b1        //
	tcy   6                          ; $357: $46        //
	tma                              ; $36e: $21        //
	tcy   7                          ; $35c: $4e        //
	tam                              ; $378: $03        //
.L371
	xbr   L380                       ; $371: $17 $80    //
.L346
	tcy   13                         ; $346: $4b        //
	imac                             ; $34d: $28        //
	br    L348                       ; $35b: $88        //
	tam                              ; $376: $03        //
	imac                             ; $36d: $28        //
	br    L369                       ; $35a: $a9        //
	br    L348                       ; $374: $88        //
.L369
	tcy   8                          ; $369: $41        //
	tcmiy 1                          ; $352: $68        //
	br    L353                       ; $364: $93        //
.L348
	tcy   14                         ; $348: $47        // Read 3:14
	imac                             ; $351: $28        // Increment it and load.
	tam                              ; $362: $03        // Write it back.
	alec  2                          ; $344: $74        // if < 2 then loop back.
	br    L34f                       ; $349: $8f        //
.L353
	tcy   0                          ; $353: $40        //
	tbit1 1                          ; $366: $3a        //
	br    L365                       ; $34c: $a5        //
	tcy   13                         ; $359: $4b        //
	tcmiy 0                          ; $372: $60        //
.L365
	tcy   0                          ; $365: $40        //
	rbit  1                          ; $34a: $36        //
	xbr   L0e4                       ; $355: $1c $a4    //
	comx                             ; $354: $00        //
	comx                             ; $368: $00        //
	comx                             ; $350: $00        //
	comx                             ; $360: $00        //

; *******************************************************

	page 14
.L380
	tcy   7                          ; $380: $4e        // Check 3:7/3:6 values ?
	tbit1 0                          ; $381: $38        //
	br    L3bd                       ; $383: $bd        //
	tbit1 1                          ; $387: $3a        //
	br    L39e                       ; $38f: $9e        //
	tbit1 2                          ; $39f: $39        //
	br    L3a7                       ; $3bf: $a7        //
	br    L3b5                       ; $3be: $b5        //
.L3bd
	tcy   6                          ; $3bd: $46        //
	tbit1 0                          ; $3bb: $38        //
	br    L3b0                       ; $3b7: $b0        //
	br    L3ac                       ; $3af: $ac        //
.L39e
	tcy   6                          ; $39e: $46        //
	tbit1 1                          ; $3bc: $3a        //
	br    L3b0                       ; $3b9: $b0        //
	br    L3ac                       ; $3b3: $ac        //
.L3a7
	tcy   6                          ; $3a7: $46        //
	tbit1 2                          ; $38e: $39        //
	br    L3b0                       ; $39d: $b0        //
	br    L3ac                       ; $3ba: $ac        //
.L3b5
	tcy   6                          ; $3b5: $46        //
	tbit1 3                          ; $3ab: $3b        //
	br    L3b0                       ; $396: $b0        //
.L3ac
	xbr   L348                       ; $3ac: $1b $88    //
.L3b0
	xbr   L346                       ; $3b0: $1b $86    //

; ***********************************************************************************
;
; 3:15, 3:7 is a 5 bit constant. Convert to a sort of log 2 value in 3:8
;
; ***********************************************************************************

.CalculateLogApprox
	tcy   15                         ; $382: $4f        // Read 3:15 into A
	tma                              ; $385: $21        //
	tcy   7                          ; $38b: $4e        // Y = 7 to read next.
	alec  1                          ; $397: $78        // If bits 1,2,3 of 3:7 are clear
	br    LogHiBitClear              ; $3ae: $b8        //
	br    LogHiBitSet                ; $39c: $b4        //
;
; This handles 3:15 = 0
;
.LogHiBitClear
	tma                              ; $3b8: $21        // Read 3:7
	tcy   8                          ; $3b1: $41        // Y = 8
	alec  1                          ; $3a3: $78        // <= 1 return 0
	br    LogReturn0                 ; $386: $84        //
	alec  2                          ; $38d: $74        // <= 2 return 1
	br    LogReturn1                 ; $39b: $93        //
	alec  4                          ; $3b6: $72        // <= 4 return 2
	br    LogReturn2                 ; $3ad: $8c        //
	br    LogReturn3                 ; $39a: $b2        // <= 7 return 3
;
; This handles 3:15 = 1
;
.LogHiBitSet
	tma                              ; $3b4: $21        // Read 3:7
	tcy   8                          ; $3a9: $41        // Y = 8 for result
	alec  1                          ; $392: $78        // <= 9 return 4
	br    LogReturn4                 ; $3a4: $8a        //
	alec  2                          ; $388: $74        // <= 10 return 5
	br    LogReturn5                 ; $391: $aa        //
	br    LogReturn6                 ; $3a2: $a8        // All other values return 6
;
; Return log values.
;
.LogReturn0
	tcmiy 0                          ; $384: $60        //
	br    LogExit                    ; $389: $90        //
.LogReturn1
	tcmiy 1                          ; $393: $68        //
	br    LogExit                    ; $3a6: $90        //
.LogReturn2
	tcmiy 2                          ; $38c: $64        //
	br    LogExit                    ; $399: $90        //
.LogReturn3
	tcmiy 3                          ; $3b2: $6c        //
	br    LogExit                    ; $3a5: $90        //
.LogReturn4
	tcmiy 4                          ; $38a: $62        //
	br    LogExit                    ; $395: $90        //
.LogReturn5
	tcmiy 5                          ; $3aa: $6a        //
	br    LogExit                    ; $394: $90        //
.LogReturn6
	tcmiy 6                          ; $3a8: $66        //
.LogExit
	retn                             ; $390: $0f        //

	cpaiz                            ; $3a0: $2d        //

; *******************************************************

	page 15

; ***********************************************************************************
;
;   Start here. Clear Block 3 and jump to start of page 0
;
; ***********************************************************************************

.RunSimon
	clo                              ; $3c0: $0b        // Clear the O outputs which aren' used.
	cla                              ; $3c1: $2f        //
	ldx   3                          ; $3c3: $3f        // Point to Block 3:15
	tcy   15                         ; $3c7: $4f        //
.ClearBlock3
	rstr                             ; $3cf: $0c        // Clear all the R lines
	tam                              ; $3df: $03        // Write $00 to all of block 3.
	dyn                              ; $3ff: $2c        //
	br    ClearBlock3                ; $3fe: $8f        //
	xbr   L000                       ; $3fd: $10 $80    //

; ***********************************************************************************
;
;     Turn the currently selected light off.
;
; ***********************************************************************************

.LightCurrentOff
	ldx   2                          ; $3f7: $3d        // Point to 2:4
	tcy   4                          ; $3ef: $42        //
	tya                              ; $3de: $23        // A = 4
	tcy   0                          ; $3fc: $40        // Point to 2:0 (current light)
	amaac                            ; $3f9: $25        // A = Current light + 4
	tay                              ; $3f3: $24        // Y = Pointer to current light
	rstr                             ; $3e7: $0c        // Turn it off
	ldx   3                          ; $3ce: $3f        //
	retn                             ; $3dd: $0f        //

.L3FA
	tcy   8                          ; $3fa: $41        // Set current state to 0
	tcmiy 0                          ; $3f5: $60        //
	br    L3d8                       ; $3eb: $98        //

.L3d6
	tcy   8                          ; $3d6: $41        //
	tcmiy 2                          ; $3ec: $64        //

.L3d8
	tcy   4                          ; $3d8: $42        // Reset the sequential page write address.
	tcmiy 0                          ; $3f0: $60        //
	tcmiy 0                          ; $3e1: $60        //
	xbr   L240                       ; $3c2: $19 $80    //

.L3cb
	tcy   9                          ; $3cb: $49        //
	tbit1 0                          ; $3d7: $38        //
	br    L3f1                       ; $3ee: $b1        //
	xbr   L000                       ; $3dc: $10 $80    //

.L3f1
	xbr   L130                       ; $3f1: $12 $b0    //

; ***********************************************************************************
;
;      Reset timer to 2560 counts.
;
; ***********************************************************************************

.PresetTimer2560
	tcy   9                          ; $3c6: $49        // Clear 3:9 bit 2 (timer flag)
	rbit  2                          ; $3cd: $35        //
	ldx   2                          ; $3db: $3d        // Point to 2:8
	tcy   8                          ; $3f6: $41        // Set counter to 0,0,10 e.g. 2560
	tcmiy 0                          ; $3ed: $60        //
	tcmiy 0                          ; $3da: $60        //
	tcmiy 10                         ; $3f4: $65        //
	ldx   3                          ; $3e9: $3f        // Fix back up
	retn                             ; $3d2: $0f        //

; ***********************************************************************************
;
;  3 nibble value from 2:8 to 2:10 is decremented, set bit 2 of 3:9 on zero.
;
; ***********************************************************************************

.DecrementTimer
	ldx   2                          ; $3e4: $3d        // Point to 2:8
	tcy   8                          ; $3c8: $41        //
	dman                             ; $3d1: $2a        //
	br    DecTimerOver               ; $3e2: $aa        // Exit if not out
	tamiy                            ; $3c4: $20        // Fix and point to 2:9
	dman                             ; $3c9: $2a        // Decrement
	br    DecTimerOver               ; $3d3: $aa        // Exit if not out
	tamiy                            ; $3e6: $20        // Fix and point to 2:10
	dman                             ; $3cc: $2a        // Decrement
	br    DecTimerOver               ; $3d9: $aa        // Exit if not out
	ldx   3                          ; $3f2: $3f        // Point to 3:9
	tcy   9                          ; $3e5: $49        //
	sbit  2                          ; $3ca: $31        // Set bit 2
	br    ExitDecTimer               ; $3d5: $94        // and exit
.DecTimerOver
	tam                              ; $3ea: $03        // Fixes up any outstanding decrement
.ExitDecTimer
	ldx   3                          ; $3d4: $3f        // X back to 3
	retn                             ; $3e8: $0f        //


	knez                             ; $3d0: $09        //
	comx                             ; $3e0: $00        //

; 2:0  current sound to play
; 2:1  number of times to play sound, length effectively.
; 2:2+ sound data and copies, 2:8..10 also 3 nibble timer.
;  3:0,1 Sequential write to page 0 address.
;   3:4  LSB of current number (1 bit)
;  3:5  Upper 4 bits of current number
; 3:8  Current selection (?)
;   3:9  (bit 2) timer.
; 3:10  current game.
; 3:12  random seed
