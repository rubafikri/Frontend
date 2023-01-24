export interface LoginRequest {
  email: string;
  password: string;
}

export interface RegisterRequest {
  email: string;
  password: string;
  firstName: string;
  lastName: string;
}

export interface AuthResponse {
  token: Token;
}

export interface Token {
  token: string;
  expiration: Date;
}
export interface User {
  email: string;
  password: string;
  firstName: string;
  lastName: string;
  addressId: number;
  id: string;
}
