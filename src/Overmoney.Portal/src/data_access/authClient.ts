import axios, { isCancel, AxiosError } from "axios";
import type { LoginResponse } from "./models/auth/loginResponse";
import type { UserProfile } from "./models/auth/profile";

export class AuthClient {

  readonly BASE_URL: string = import.meta.env.VITE_API_URL == "" 
    ? "http://" + window.location.hostname + ":" + import.meta.env.VITE_API_PORT + "/"
    : import.meta.env.VITE_API_URL;

  async loginUser(email: string, password: string): Promise<LoginResponse> {
    const response = await axios.post<LoginResponse>(
      this.BASE_URL +
        `Identity/login?useCookies=false&useSessionCookies=false`,
      { email, password }
    );
    return response.data;
  }

  async getUserProfile(token: string): Promise<UserProfile> {
    const response = await axios.get<UserProfile>(
      this.BASE_URL + `users/profile`,
      {
        headers: {
          Authorization: `Bearer ${token}`,
        },
      }
    );
    return response.data;
  }

  async registerUser(email: string, password: string): Promise<number> {
    const response = await axios.post(
      this.BASE_URL + `Identity/register`,
      { email, password }
    );
    return response.status;
  }

  async createUserProfile(email: string): Promise<UserProfile> {
    const response = await axios.post<UserProfile>(
      this.BASE_URL + `users/profile`,
      { email }
    );
    return response.data;
  }
}
