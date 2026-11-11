import { StrictMode, useEffect, useState } from 'react'
import { createRoot } from 'react-dom/client'

function App() {
  const [status, setStatus] = useState('Connecting to API…')

  useEffect(() => {
    const request = new AbortController()

    async function checkApi() {
      try {
        const response = await fetch('/api/health', { signal: request.signal })
        if (!response.ok) {
          throw new Error('Health check failed')
        }

        const result: { status?: string } = await response.json()
        setStatus(result.status === 'ok' ? 'API connected' : 'API unavailable')
      } catch {
        if (!request.signal.aborted) {
          setStatus('API unavailable')
        }
      }
    }

    void checkApi()
    return () => request.abort()
  }, [])

  return (
    <main>
      <h1>Dambrug</h1>
      <p role="status">{status}</p>
    </main>
  )
}

createRoot(document.getElementById('root')!).render(
  <StrictMode>
    <App />
  </StrictMode>,
)
