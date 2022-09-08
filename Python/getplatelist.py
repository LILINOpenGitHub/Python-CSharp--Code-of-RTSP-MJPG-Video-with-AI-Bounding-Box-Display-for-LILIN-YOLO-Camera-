
import http.client
import base64
username = 'admin'
password = 'Pass1234'
userpass = username + ':' + password
encoded_u = base64.b64encode(userpass.encode()).decode()
headers = {"Authorization" : "Basic %s" % encoded_u}
print(headers)

connection = http.client.HTTPConnection('61.216.97.157', 8099, timeout=10)
connection.request('GET', '/server', headers=headers)
response = connection.getresponse()
data = response.read()
print("Server information", data)

connection.request('GET', '/get_search_info?list=log', headers=headers)
response = connection.getresponse()
data = response.read()
print("Number plate list", data)

connection.close()
