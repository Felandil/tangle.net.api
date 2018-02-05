C# Web Api to store and retrieve small files on the tangle (https://github.com/iotaledger/), build to fit into Clean Architecture (see below).

![cleanarch](http://i.imgur.com/WkBAATy.png)

More information:
http://blog.8thlight.com/uncle-bob/2012/08/13/the-clean-architecture.html


## Donate

```javascript
YTXCUUWTXIXVRQIDSECVFRTKAFOEZITGDPLWYVUVFURMNVDPIRXEIQN9JHNFNVKVJMQVMA9GDZJROTSFZHIVJOVAEC
```

## Getting started

The API uses localhost as Node. You can change that by adjusting the node in the ApiNinjectModule.

The API uses CPU PoW by default.

Storing a file: 

The input data has to be sent in binary form, which can be done via Postman for example
```
POST http://localhost:3810/v1/store/YTXCUUWTXIXVRQIDSECVFRTKAFOEZITGDPLWYVUVFURMNVDPIRXEIQN9JHNFNVKVJMQVMA9GDZJROTSFZ
```

Retrieving a file (you can use the example URI, which will output a jpg file)

```
GET http://localhost:3810/v1/files/EEXMFQJIFFCPPCBPIRGACWGPSZYJCRALLS9FRIEWTVEXXCNZFEU99RDIQJSDRPUTY9JTPNXNJUMNA9999
```

Please note that the process takes longer the bigger the file. For testing purposes I'd suggest not to take files bigger than 10 KB
