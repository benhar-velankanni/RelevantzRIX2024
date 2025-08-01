ß
iD:\L1 core topics\ASP.NET Core Web API\Web API\StorageConnectorService\StorageConnectorService\Program.cs
var		 
builder		 
=		 
WebApplication		 
.		 
CreateBuilder		 *
(		* +
args		+ /
)		/ 0
;		0 1
builder 
. 
Services 
. 
AddControllers 
(  
)  !
;! "
builder 
. 
Services 
. 
AddDbContext 
< 
AppDBContext *
>* +
(+ ,
options, 3
=>4 6
options 
. 
UseMySql 
( 
builder 
. 
Configuration 
. 
GetConnectionString .
(. /
$str/ B
)B C
,C D
ServerVersion 
. 

AutoDetect 
( 
builder %
.% &
Configuration& 3
.3 4
GetConnectionString4 G
(G H
$strH [
)[ \
)\ ]
)] ^
)^ _
;_ `
builder 
. 
Services 
. #
AddEndpointsApiExplorer (
(( )
)) *
;* +
builder 
. 
Services 
. 
AddSwaggerGen 
( 
)  
;  !
var 
app 
= 	
builder
 
. 
Build 
( 
) 
; 
if 
( 
app 
. 
Environment 
. 
IsDevelopment !
(! "
)" #
)# $
{ 
app 
. 

UseSwagger 
( 
) 
; 
app 
. 
UseSwaggerUI 
( 
c 
=> 
{ 
c   	
.  	 

SwaggerEndpoint  
 
(   
$str   4
,  4 5
$str  6 O
)  O P
;  P Q
}!! 
)!! 
;!! 
}"" 
app$$ 
.$$ 
UseHttpsRedirection$$ 
($$ 
)$$ 
;$$ 
app&& 
.&& 
UseAuthorization&& 
(&& 
)&& 
;&& 
app(( 
.(( 
MapControllers(( 
((( 
)(( 
;(( 
app** 
.** 
Run** 
(** 
)** 	
;**	 
ä
xD:\L1 core topics\ASP.NET Core Web API\Web API\StorageConnectorService\StorageConnectorService\Model\StorageConnector.cs
	namespace 	#
StorageConnectorService
 !
.! "
Model" '
{ 
public 

class 
StorageConnector !
{ 
[ 	
Key	 
] 
public 
int 
StorageConnectorId %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
[ 	
Required	 
] 
public		 
string		  
StorageConnectorName		 *
{		+ ,
get		- 0
;		0 1
set		2 5
;		5 6
}		7 8
[

 	
Required

	 
]

 
public 
string '
StorageConnectorDescription 1
{2 3
get4 7
;7 8
set9 <
;< =
}> ?
} 
} •
ƒD:\L1 core topics\ASP.NET Core Web API\Web API\StorageConnectorService\StorageConnectorService\Migrations\20250710061743_Initial.cs
	namespace 	#
StorageConnectorService
 !
.! "

Migrations" ,
{ 
public		 

partial		 
class		 
Initial		  
:		! "
	Migration		# ,
{

 
	protected 
override 
void 
Up  "
(" #
MigrationBuilder# 3
migrationBuilder4 D
)D E
{ 	
migrationBuilder 
. 
AlterDatabase *
(* +
)+ ,
. 

Annotation 
( 
$str +
,+ ,
$str- 6
)6 7
;7 8
migrationBuilder 
. 
CreateTable (
(( )
name 
: 
$str )
,) *
columns 
: 
table 
=> !
new" %
{ 
StorageConnectorId &
=' (
table) .
.. /
Column/ 5
<5 6
int6 9
>9 :
(: ;
type; ?
:? @
$strA F
,F G
nullableH P
:P Q
falseR W
)W X
. 

Annotation #
(# $
$str$ C
,C D(
MySqlValueGenerationStrategyE a
.a b
IdentityColumnb p
)p q
,q r 
StorageConnectorName (
=) *
table+ 0
.0 1
Column1 7
<7 8
string8 >
>> ?
(? @
type@ D
:D E
$strF P
,P Q
nullableR Z
:Z [
false\ a
)a b
. 

Annotation #
(# $
$str$ 3
,3 4
$str5 >
)> ?
,? @'
StorageConnectorDescription /
=0 1
table2 7
.7 8
Column8 >
<> ?
string? E
>E F
(F G
typeG K
:K L
$strM W
,W X
nullableY a
:a b
falsec h
)h i
. 

Annotation #
(# $
$str$ 3
,3 4
$str5 >
)> ?
} 
, 
constraints 
: 
table "
=># %
{ 
table 
. 

PrimaryKey $
($ %
$str% ;
,; <
x= >
=>? A
xB C
.C D
StorageConnectorIdD V
)V W
;W X
} 
) 
.   

Annotation   
(   
$str   +
,  + ,
$str  - 6
)  6 7
;  7 8
}!! 	
	protected$$ 
override$$ 
void$$ 
Down$$  $
($$$ %
MigrationBuilder$$% 5
migrationBuilder$$6 F
)$$F G
{%% 	
migrationBuilder&& 
.&& 
	DropTable&& &
(&&& '
name'' 
:'' 
$str'' )
)'') *
;''* +
}(( 	
})) 
}** ø
sD:\L1 core topics\ASP.NET Core Web API\Web API\StorageConnectorService\StorageConnectorService\Data\AppDBContext.cs
	namespace 	#
StorageConnectorService
 !
.! "
Data" &
{ 
public 

class 
AppDBContext 
: 
	DbContext  )
{ 
public 
AppDBContext 
( 
DbContextOptions ,
<, -
AppDBContext- 9
>9 :
options; B
)B C
:D E
baseF J
(J K
optionsK R
)R S
{T U
}V W
public		 
DbSet		 
<		 
StorageConnector		 %
>		% &
StorageConnectors		' 8
{		9 :
get		; >
;		> ?
set		@ C
;		C D
}		E F
}

 
} ï4
‰D:\L1 core topics\ASP.NET Core Web API\Web API\StorageConnectorService\StorageConnectorService\Controllers\StorageConnectorsController.cs
	namespace 	#
StorageConnectorService
 !
.! "
Controllers" -
{ 
[ 
Route 

(
 
$str 
) 
] 
[ 
ApiController 
] 
public 

class '
StorageConnectorsController ,
:- .
ControllerBase/ =
{ 
private 
readonly 
AppDBContext %
_context& .
;. /
public '
StorageConnectorsController *
(* +
AppDBContext+ 7
context8 ?
)? @
{ 	
_context 
= 
context 
; 
} 	
[ 	
HttpGet	 
] 
public 
async 
Task 
< 
ActionResult &
<& '
IEnumerable' 2
<2 3
StorageConnector3 C
>C D
>D E
>E F 
GetStorageConnectorsG [
([ \
)\ ]
{ 	
return 
await 
_context !
.! "
StorageConnectors" 3
.3 4
ToListAsync4 ?
(? @
)@ A
;A B
} 	
[   	
HttpGet  	 
(   
$str   
)   
]   
public!! 
async!! 
Task!! 
<!! 
ActionResult!! &
<!!& '
StorageConnector!!' 7
>!!7 8
>!!8 9
GetStorageConnector!!: M
(!!M N
int!!N Q
id!!R T
)!!T U
{"" 	
var## 
storageConnector##  
=##! "
await### (
_context##) 1
.##1 2
StorageConnectors##2 C
.##C D
	FindAsync##D M
(##M N
id##N P
)##P Q
;##Q R
if%% 
(%% 
storageConnector%%  
==%%! #
null%%$ (
)%%( )
{&& 
return'' 
NotFound'' 
(''  
)''  !
;''! "
}(( 
return** 
storageConnector** #
;**# $
}++ 	
[// 	
HttpPut//	 
(// 
$str// 
)// 
]// 
public00 
async00 
Task00 
<00 
IActionResult00 '
>00' (
PutStorageConnector00) <
(00< =
int00= @
id00A C
,00C D
StorageConnector00E U
storageConnector00V f
)00f g
{11 	
if22 
(22 
id22 
!=22 
storageConnector22 &
.22& '
StorageConnectorId22' 9
)229 :
{33 
return44 

BadRequest44 !
(44! "
)44" #
;44# $
}55 
_context77 
.77 
Entry77 
(77 
storageConnector77 +
)77+ ,
.77, -
State77- 2
=773 4
EntityState775 @
.77@ A
Modified77A I
;77I J
try99 
{:: 
await;; 
_context;; 
.;; 
SaveChangesAsync;; /
(;;/ 0
);;0 1
;;;1 2
}<< 
catch== 
(== (
DbUpdateConcurrencyException== /
)==/ 0
{>> 
if?? 
(?? 
!?? "
StorageConnectorExists?? +
(??+ ,
id??, .
)??. /
)??/ 0
{@@ 
returnAA 
NotFoundAA #
(AA# $
)AA$ %
;AA% &
}BB 
elseCC 
{DD 
throwEE 
;EE 
}FF 
}GG 
returnII 
	NoContentII 
(II 
)II 
;II 
}JJ 	
[NN 	
HttpPostNN	 
]NN 
publicOO 
asyncOO 
TaskOO 
<OO 
ActionResultOO &
<OO& '
StorageConnectorOO' 7
>OO7 8
>OO8 9 
PostStorageConnectorOO: N
(OON O
StorageConnectorOOO _
storageConnectorOO` p
)OOp q
{PP 	
_contextQQ 
.QQ 
StorageConnectorsQQ &
.QQ& '
AddQQ' *
(QQ* +
storageConnectorQQ+ ;
)QQ; <
;QQ< =
awaitRR 
_contextRR 
.RR 
SaveChangesAsyncRR +
(RR+ ,
)RR, -
;RR- .
returnTT 
CreatedAtActionTT "
(TT" #
$strTT# 8
,TT8 9
newTT: =
{TT> ?
idTT@ B
=TTC D
storageConnectorTTE U
.TTU V
StorageConnectorIdTTV h
}TTi j
,TTj k
storageConnectorTTl |
)TT| }
;TT} ~
}UU 	
[XX 	

HttpDeleteXX	 
(XX 
$strXX 
)XX 
]XX 
publicYY 
asyncYY 
TaskYY 
<YY 
IActionResultYY '
>YY' ("
DeleteStorageConnectorYY) ?
(YY? @
intYY@ C
idYYD F
)YYF G
{ZZ 	
var[[ 
storageConnector[[  
=[[! "
await[[# (
_context[[) 1
.[[1 2
StorageConnectors[[2 C
.[[C D
	FindAsync[[D M
([[M N
id[[N P
)[[P Q
;[[Q R
if\\ 
(\\ 
storageConnector\\  
==\\! #
null\\$ (
)\\( )
{]] 
return^^ 
NotFound^^ 
(^^  
)^^  !
;^^! "
}__ 
_contextaa 
.aa 
StorageConnectorsaa &
.aa& '
Removeaa' -
(aa- .
storageConnectoraa. >
)aa> ?
;aa? @
awaitbb 
_contextbb 
.bb 
SaveChangesAsyncbb +
(bb+ ,
)bb, -
;bb- .
returndd 
	NoContentdd 
(dd 
)dd 
;dd 
}ee 	
privategg 
boolgg "
StorageConnectorExistsgg +
(gg+ ,
intgg, /
idgg0 2
)gg2 3
{hh 	
returnii 
_contextii 
.ii 
StorageConnectorsii -
.ii- .
Anyii. 1
(ii1 2
eii2 3
=>ii4 6
eii7 8
.ii8 9
StorageConnectorIdii9 K
==iiL N
idiiO Q
)iiQ R
;iiR S
}jj 	
}kk 
}ll 