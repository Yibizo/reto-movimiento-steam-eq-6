const express = require('express');
const mysql = require('mysql');
const cors = require('cors');

const app = express();
const port = 5000;


app.use(cors());
app.use(express.json());
app.use(express.urlencoded({extended: true}));

function connectToDB()
{
    try{
        return mysql.createConnection({host:'localhost', user:'admin', password:'Gamer123', database:'api_game'});
    }
    catch(error){
        console.log(error);
    }
}

//app.get('/', (req, res) => {
//	res.redirect('/api/gamedata');
//});
//SELECT MAX(id) FROM mytable

/* Getting a user from ID
app.get("/public/users/:id",(req, res) => {
	
	const {id } = req.params
	const q = `Select * FROM users WHERE user_id = ${id}`;

	connection.query(q, (err, result) => {
		if (result.length > 0){
			res.json(result)
		} 
		else{
			res.send("No user found")
		}
	})

});*/

app.post('/api/initial', (request, response)=>{

    try{
        console.log('Request data:', request.body);
        let connection = connectToDB();
        connection.connect();
        // Conveniently, the names of the fields match the names of the database columns, and we can insert the data as follows:
        
        const query = connection.query('insert into game_data set ?', request.body ,(error, results, fields)=>{

            // If there are no errors, we send a message back to unity that the data was inserted correctly.
            if(error)
                console.log(error);
            else
                response.send(`${results.insertId}`);

        });

        // Log everything in the server console.
        console.log(query.sql);
        connection.end();
    }
    catch(error)
    {
        console.log(error);
        connection.end();
        response.json(error);
    }
});

app.put('/api/update', (req, response)=>{
    
    try{
        console.log('Request data:', req.body);
        let connection = connectToDB();
        connection.connect();
        console.log("Request " + req);
        console.log("Request " + req.body);
        //console.log("Request " + req.body.?user_id);
        console.log("Response " + response.body);
        const id = req.body.user_id;
        const level = req.body.level;
        const area_id = req.body.area_id;
        const problems_a1 = req.body.problems_a1;
        const problems_a2 = req.body.problems_a2;
        const problems_a3 = req.body.problems_a3;
        

        const q = `UPDATE game_data SET level = "${level}", area_id = "${area_id}", problems_a1 = "${problems_a1}", problems_a2 = "${problems_a2}", problems_a3 = "${problems_a3}" WHERE user_id = "${id}"`;
        // Conveniently, the names of the fields match the names of the database columns, and we can insert the data as follows:
        const query = connection.query(q ,(error, results, fields)=>{

            // If there are no errors, we send a message back to unity that the data was inserted correctly.
            if(error)
                console.log(error);
            else
                response.json({'message': "Data inserted correctly."})
        });

        // Log everything in the server console.
        console.log(query.sql);
        connection.end();
    }
    catch(error)
    {
        console.log(error);
        connection.end();
        response.json(error);
    }
});


/*app.put("/public/update-user/:id", (req,res) => {
	const id = req.body.id;
	//const {first_name, last_name, email} = req.body
	const first_name = req.body.first_name;
	const last_name = req.body.last_name;
	const email = req.body.email;
	
	const q = `UPDATE users SET first_name = "${first_name}", last_name = "${last_name}", email = "${email}" WHERE user_id = ${id}`;

	connection.query(q, error => {
		if (error) throw error;
		res.send("User updated");
	})
});*/

app.listen(port, ()=>
{
    console.log(`App listening at http://localhost:${port}`);
});