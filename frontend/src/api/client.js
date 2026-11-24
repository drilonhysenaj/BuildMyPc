const API_URL = import.meta.env.VITE_API_URL ?? "http://localhost:5126";

export async function apiRequest(path, options = {}) {
  const response = await fetch(`${API_URL}${path}`, {
    ...options,
    headers: {
      "Content-Type": "application/json",
      ...options.headers,
    },
  });

  if (!response.ok) {
    const message = await response.text();
    throw new Error(message || `Gabim ${response.status}`);
  }

  if (response.status === 204) return null;
  return response.json();
}

//I dërgon një kërkesë backend-it dhe ta kthen përgjigjen.
//Është saktë ajo që bën butoni Execute në Swagger,
//por nga kodi i React-it.

//Ndërton adresën e plotë: http://localhost:5126 + p.sh. /api/products.
//E dërgon kërkesën me fetch, dhe i thotë serverit "po flas me JSON".
//E kontrollon përgjigjen: nëse kodi s'është 200–299, p.sh. 404 ose 400, hedh gabim.
//Ta kthen të dhënat: e kthen JSON-in në objekt JavaScript. Nëse është 204, kthen null.