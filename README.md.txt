CHAMADAS 

*****ROTA DE CRIAÇÃO DE USUÁRIO*****
https://authentication-pitang.herokuapp.com/api/signup

-----Exemplo de formato json-----
    {       
        "Id": 0,
        "firstName": "usuario",
        "lastName": "sobrenome",
        "email": "usuario@yahoo.com",
        "passWord": "123456",
        "phones": [
        {
            "id":0,
            "userId":0,
            "number":888888888,
            "area_code":81,
            "country_code":"+55"

           
            
        },{
            "id":0,
            "userId":0,
            "number":1111111111,
            "area_code":81,
            "country_code":"+55"
            
        }
        ]
    }

========================================================
*****ROTA DE LOGIN*****

https://authentication-pitang.herokuapp.com/api/signin

-----Exemplo de formato json-----

    {       
     "email": "lorran@yahoo.com",
     "passWord": "123456"
    }
	
	
*****ROTA DO TOKEN*****	
https://authentication-pitang.herokuapp.com/api/me
-----Exemplo passando token via Header (utilizando token retornado do exemplo acima)-----

KEY                 VALUE
Authorization	    Bearer token