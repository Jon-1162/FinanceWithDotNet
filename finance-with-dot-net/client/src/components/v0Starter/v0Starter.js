/**
 * v0 by Vercel.
 * @see https://v0.dev/t/e8bV5E8zbK4
 * Documentation: https://v0.dev/docs#integrating-generated-code-into-your-nextjs-app
 */
import { Card, CardHeader, CardTitle, CardDescription, CardContent } from "@/components/ui/card"
import { Label } from "@/components/ui/label"
import { Input } from "@/components/ui/input"
import { Button } from "@/components/ui/button"
import { ResponsiveLine } from "@nivo/line"

export default function Component() {
  return (
    <div className="grid grid-cols-1 md:grid-cols-[1fr_300px] gap-6 max-w-6xl mx-auto p-4 md:p-8">
      <Card className="h-full">
        <CardHeader>
          <CardTitle>Stock Performance</CardTitle>
          <CardDescription>View the stock price performance for the selected time period and ticker.</CardDescription>
        </CardHeader>
        <CardContent>
          <LineChart className="aspect-[16/9]" />
        </CardContent>
      </Card>
      <div className="grid gap-6">
        <Card>
          <CardHeader>
            <CardTitle>Settings</CardTitle>
          </CardHeader>
          <CardContent className="grid gap-4">
            <div className="grid gap-2">
              <Label htmlFor="start-date">Start Date</Label>
              <Input type="date" id="start-date" defaultValue="2023-01-01" />
            </div>
            <div className="grid gap-2">
              <Label htmlFor="end-date">End Date</Label>
              <Input type="date" id="end-date" defaultValue="2023-12-31" />
            </div>
            <div className="grid gap-2">
              <Label htmlFor="stock-ticker">Stock Ticker</Label>
              <Input type="text" id="stock-ticker" defaultValue="AAPL" />
            </div>
            <div className="grid gap-2">
              <Label htmlFor="start-amount">Starting Amount</Label>
              <Input type="number" id="start-amount" defaultValue="10000" />
            </div>
            <Button>Update</Button>
          </CardContent>
        </Card>
      </div>
    </div>
  )
}

function LineChart(props) {
  return (
    <div {...props}>
      <ResponsiveLine
        data={[
          {
            id: "Desktop",
            data: [
              { x: "Jan", y: 43 },
              { x: "Feb", y: 137 },
              { x: "Mar", y: 61 },
              { x: "Apr", y: 145 },
              { x: "May", y: 26 },
              { x: "Jun", y: 154 },
            ],
          },
          {
            id: "Mobile",
            data: [
              { x: "Jan", y: 60 },
              { x: "Feb", y: 48 },
              { x: "Mar", y: 177 },
              { x: "Apr", y: 78 },
              { x: "May", y: 96 },
              { x: "Jun", y: 204 },
            ],
          },
        ]}
        margin={{ top: 10, right: 10, bottom: 40, left: 40 }}
        xScale={{
          type: "point",
        }}
        yScale={{
          type: "linear",
        }}
        axisTop={null}
        axisRight={null}
        axisBottom={{
          tickSize: 0,
          tickPadding: 16,
        }}
        axisLeft={{
          tickSize: 0,
          tickValues: 5,
          tickPadding: 16,
        }}
        colors={["#2563eb", "#e11d48"]}
        pointSize={6}
        useMesh={true}
        gridYValues={6}
        theme={{
          tooltip: {
            chip: {
              borderRadius: "9999px",
            },
            container: {
              fontSize: "12px",
              textTransform: "capitalize",
              borderRadius: "6px",
            },
          },
          grid: {
            line: {
              stroke: "#f3f4f6",
            },
          },
        }}
        role="application"
      />
    </div>
  )
}