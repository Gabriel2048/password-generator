import { useEnv } from "../../providers/useEnv";
import { CreatedPasswordResponse } from "./createdPasswordResponse";

export const usePasswordApi = () => {

    const { apiUrl } = useEnv();
    const passwordEndpoint = `${apiUrl}/password`;

    const createPassword = async (userId: string): Promise<CreatedPasswordResponse> => {
        const response = await fetch(passwordEndpoint, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(userId),
        });

        const passwordResponse: { password: string, expiresAt: string } = await response.json();
        return {
            password: passwordResponse.password,
            expiresAt: new Date(Date.parse(passwordResponse.expiresAt))
        };
    };

    return {
        createPassword,
    }
};