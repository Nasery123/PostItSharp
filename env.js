// after filling all the information fro account i mean auth then  the table in sqlsetup make a talble
export const dev = window.location.origin.includes('localhost')
export const baseURL = dev ? 'http://localhost:3000' : ''
export const useSockets = false
export const domain = 'dev-kiauhaovz2vrggl7.us.auth0.com'
export const clientId = 'Vp8GGDUFeQjoiZRrpj5px2MndaeYbcv8'
export const audience = 'http://sandbox.com'
