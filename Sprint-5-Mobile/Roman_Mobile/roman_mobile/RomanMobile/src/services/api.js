import axios from 'axios';

const api = axios.create({

//baseURL: 'http://192.168.1.112:5000/api'

// api joao
//  baseURL: 'http://192.168.5.152:5000/api'

// api rafa
 baseURL: 'http://192.168.15.34:5000/api'
// baseURL: 'http://192.168.4.55:5000/api' 

//pegar ip: abrir cmd e escrever 'ipconfig' ->  Endereço IPv4
});

export default api;