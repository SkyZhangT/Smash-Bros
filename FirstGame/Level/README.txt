1.Level Definition Format:										
Floor,Step,HiddenBrick,Brick,EmptyBox, Pipes		BlockType						
HiddenBox						BlockType/CoinLeftNumber		(0 means no coin)
CoinBox with one item including a coin			BlockType/ItemType
										
Avator							Player		(Avator can only have 0 initial speed)				
										
Enemy							EnemyType/InitialHorizonalSpeed		
										
Mushrooms						ItemType/InitialHorizonalSpeed			
Item except Mushrooms					ItemType	

Checkpoint						Floor/C		(find any Floor and add /C)
									(Avator initial position is already recorded as a checkpoint)


2.To change the level, change the xlsx file and save. Then also save it as csv file to replace the original csv file
Do no change and save csv file directly!
