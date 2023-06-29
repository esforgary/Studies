from flask import Flask, request, jsonify
from pymongo import MongoClient
from bson.objectid import ObjectId

app = Flask(__name__)
client = MongoClient('mongodb://localhost:27017/')
db = client['mydatabase']

@app.route('/users', methods=['GET'])
def get_users():
    query = {}
    name = request.args.get('name')
    if name:
        query['name'] = name
        
    users = db.users.find(query)
    return jsonify(users)

@app.route('/users/<user_id>', methods=['GET'])
def get_user(user_id):
    user = db.users.find_one({'_id': ObjectId(user_id)})
    if not user:
        return jsonify({'message': 'User not found'}), 404
    return jsonify(user)

@app.route('/users', methods=['POST'])
def create_user():
    data = request.get_json()
    name = data.get('name')
    age = data.get('age')
    
    if not name or not age:
        return jsonify({'message': 'Name and age are required'}), 400
    
    user = {'name': name, 'age': age}
    result = db.users.insert_one(user)
    
    return jsonify({'message': 'User created successfully', 'user_id': str(result.inserted_id)}), 201

@app.route('/users/<user_id>', methods=['PUT'])
def update_user(user_id):
    data = request.get_json()
    name = data.get('name')
    age = data.get('age')
    
    if not name or not age:
        return jsonify({'message': 'Name and age are required'}), 400
    
    result = db.users.update_one({'_id': ObjectId(user_id)}, {'$set': {'name': name, 'age': age}})
    if result.modified_count == 0:
        return jsonify({'message': 'User not found'}), 404
    
    return jsonify({'message': 'User updated successfully'})

@app.route('/users/<user_id>', methods=['DELETE'])
def delete_user(user_id):
    result = db.users.delete_one({'_id': ObjectId(user_id)})
    if result.deleted_count == 0:
        return jsonify({'message': 'User not found'}), 404
    
    return jsonify({'message': 'User deleted successfully'})

if __name__ == '__main__':
    app.run()
